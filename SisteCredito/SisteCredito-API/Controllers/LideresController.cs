using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Dtos.LideresDto;
using SisteCredito_Core.Models;
using SisteCredito_Infrastructure.Data;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;
using SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;
using SisteCredito_Infrastructure.Data.Repository.RepositorioLideres;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LideresController : ControllerBase
    {
        private readonly IRepositoryLideres _lideresRepo;
        private readonly IMapper _mapper;
        private readonly IRepositoryGeneros _generoRepo;
        private readonly IRepositoryAreas _areasRepo;
        private ApplicationDbContext _db;

        public LideresController(
            IRepositoryLideres lideresRepo, 
            IMapper mapper, 
            ApplicationDbContext db,
            IRepositoryGeneros generoRepo,
            IRepositoryAreas areasRepo
            )
        {
            _lideresRepo = lideresRepo;
            _mapper = mapper;
            _db= db;
            _generoRepo = generoRepo;
            _areasRepo = areasRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarLideres ()
        {
        
            var lideres = _db.Lideres
                            .Include(c => c.Areas).ToList();
            return Ok(await _lideresRepo.ObtenerTodos());
        }

        [HttpGet("{id:int}", Name ="ObtenerLiderPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LideresResponseDto>> ObtenerLiderPorId (int id)
        {

            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var lider = await _lideresRepo.Obtener(x => x.Id == id);

            if(lider is null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no tiene ningún valor asociado");
                return NotFound(ModelState);
            }

            return Ok(lider);
        }        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CrearLider([FromBody] LideresRequestDto LiderRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(LiderRequest is null)
            {
                return BadRequest();
            }

            Lideres lideres = _mapper.Map<Lideres>(LiderRequest);

            await _lideresRepo.Crear(lideres);
            
            return CreatedAtRoute("ObtenerPorId", new {id = lideres.Id}, lideres);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarLider (int id)
        {

            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var lider = await _lideresRepo.Obtener(x => x.Id == id);

            if(lider is null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no tiene ningún valor asociado");
                return NotFound(ModelState);
            }

            await _lideresRepo.Remover(lider);

            return NoContent();
        }         

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarLider (int id, [FromBody]LideresUpdateDto liderRequest)
        {

            if(id != liderRequest.Id || liderRequest is null)
            {
                ModelState.AddModelError("ErrorId", $"Error con la información recibida {liderRequest}");
                return BadRequest(ModelState);
            }

            Lideres lider = _mapper.Map<Lideres>(liderRequest);

            await _lideresRepo.Actualizar(lider);

            return NoContent();
        }           


    }
}