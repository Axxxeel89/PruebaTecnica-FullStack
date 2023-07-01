using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Core.Dtos.AreasDto;
using SisteCredito_Core.Dtos.EmpleadosDto;
using SisteCredito_Core.Models;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IRepositoryAreas _areasRepo;
        private readonly IMapper _mapper;

        public AreasController(IRepositoryAreas areasRepo, IMapper mapper)
        {
            _areasRepo = areasRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAllAreas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllAreas()
        {
            return Ok(await _areasRepo.ObtenerTodos());
        }

        [HttpGet("{id:int}", Name = "GetAreaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AreasResponseDto>> GetAreaById(int id)
        {
            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var areas = await _areasRepo.Obtener(c => c.Id == id);

            if(areas == null)
            {
                ModelState.AddModelError("Error", $"El id={id} no tiene un registro asociado");
                return NotFound(ModelState);
            }

            AreasResponseDto areasResponse = _mapper.Map<AreasResponseDto>(areas);

            return Ok(areasResponse);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CrearArea([FromBody] AreasRequestDto areasRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _areasRepo.Obtener(c=> c.Nombre.ToLower() == areasRequest.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("Existe", "El área con ese nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (areasRequest == null)
            {
                return BadRequest(areasRequest); //-> Devolvemos nuevame lo que nos envian
            }

            Areas areas = _mapper.Map<Areas>(areasRequest);

            await _areasRepo.Crear(areas);

            return CreatedAtRoute("GetAreaById", new {id = areas.Id}, areas);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> EliminarArea(int id)
        {
            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var areas = await _areasRepo.Obtener(c => c.Id == id);

            if(areas == null)
            {
                ModelState.AddModelError("Error", $"El id={id} no tiene un registro asociado");
                return NotFound(ModelState);
            }

            await _areasRepo.Remover(areas);

            return NoContent();

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarArea(int id, [FromBody]AreasUpdateDto request)
        {
            if(id != request.Id || request == null  )
            {
                ModelState.AddModelError("ErrorId", $"El objeto con Id:{id} no es valido");
                return BadRequest(ModelState);
            }

            Areas areas = _mapper.Map<Areas>(request);

            _areasRepo.Actualizar(areas);

            return NoContent();

        }
    }
}