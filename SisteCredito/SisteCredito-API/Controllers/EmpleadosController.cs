using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Core.Dtos.EmpleadosDto;
using SisteCredito_Core.Models;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEmpleado;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepositoryEmpleados _empRepo;
        private readonly IMapper _mapper;

        public EmpleadosController(IRepositoryEmpleados empRepo, IMapper mapper)
        {
            _empRepo = empRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadosResponseDto>> ListarEmpleados()
        {
            return Ok(await _empRepo.ObtenerTodos());
        }

        [HttpGet("{id:int}", Name ="ObtenerPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadosResponseDto>> ObtenerPorId(int id)
        {
            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var empleados = await _empRepo.Obtener(x => x.Id == id);

            if(empleados is null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no tiene ningun valor asociado");
                return NotFound(ModelState);
            }


            return Ok(empleados);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadosResponseDto>> CrearEmpleado (EmpleadosRequestDto request)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(request is null)
            {
                return BadRequest();
            }

            Empleados empleados = _mapper.Map<Empleados>(request);

            await _empRepo.Crear(empleados);
            
            return CreatedAtRoute("ObtenerPorId", new {id = empleados.Id}, empleados);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarEmpleado (int id)
        {
            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var empleados = await _empRepo.Obtener(x => x.Id == id);

            if(empleados is null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no tiene ningun valor asociado");
                return NotFound(ModelState);
            }

            await _empRepo.Remover(empleados);

            return NoContent();

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarEmpleado (int id, [FromBody] EmpleadosUpdateDto request)
        {
            if(id != request.Id || request == null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            Empleados empleados = _mapper.Map<Empleados>(request);

            await _empRepo.Actualizar(empleados);

            return NoContent();

        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizacionParcialEmpleado(int id, JsonPatchDocument<EmpleadosUpdateDto> patchDto)
        {
            if(id == 0 || patchDto is null)
            {
                return BadRequest();
            }

            var empleado = await _empRepo.Obtener( e => e.Id == id, tracked: false);

            if(empleado is null) return NotFound();

            EmpleadosUpdateDto empleadosUpdateDto = _mapper.Map<EmpleadosUpdateDto>(empleado);

            patchDto.ApplyTo(empleadosUpdateDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Empleados empleados = _mapper.Map<Empleados>(empleadosUpdateDto);

            await _empRepo.Actualizar(empleados);

            return NoContent();
        }


    }
}