using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Core.Dtos.ReporteHoraExtraDto;
using SisteCredito_Core.Models;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteHorasExtraController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryReporteHorasExtra _reporteHoraRepo;
        private readonly ILogger<ReporteHorasExtraController> _logger;

        public ReporteHorasExtraController(
            IMapper mapper, 
            IRepositoryReporteHorasExtra reporteHoraRepo,
            ILogger<ReporteHorasExtraController> ilogger
            )
        {
            _mapper = mapper;
            _reporteHoraRepo = reporteHoraRepo;
            _logger = ilogger;
        }

        [HttpGet("nombreUsuario:string")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarHorasExtra (string nombreUsuario)
        {
            _logger.LogInformation($"{nombreUsuario}");
            var listado = await _reporteHoraRepo.ObtenerConRelaciones(nombreUsuario);
            return Ok(listado);
        }

        [HttpGet("{id:int}", Name = "ObtenerHoraExtraById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerHoraExtraById (int id)
        {
            
            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var horaExtra = await _reporteHoraRepo.Obtener(x => x.Id == id);

            if(horaExtra is null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no tiene ningún valor asociado");
                return NotFound(ModelState);
            }

            return Ok(horaExtra);
        }
        


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CrearHoraExtra ([FromBody] ReporteHorasExtraRequestDto reporteHoraRequest)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(reporteHoraRequest is null)
            {
                ModelState.AddModelError("Error", $"Error la data puede estar vacia {reporteHoraRequest}");
                return BadRequest();
            }

            ReporteHorasExtra reporteHorasExtra = _mapper.Map<ReporteHorasExtra>(reporteHoraRequest);

            await _reporteHoraRepo.Crear(reporteHorasExtra);
            
            return CreatedAtRoute("ObtenerHoraExtraById", new {id = reporteHorasExtra.Id}, reporteHorasExtra);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarReporteHora (int id)
        {
            
            if(id == 0)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            var horaExtra = await _reporteHoraRepo.Obtener(x => x.Id == id);

            if(horaExtra is null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no tiene ningún valor asociado");
                return NotFound(ModelState);
            }

            await _reporteHoraRepo.Remover(horaExtra);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarReporte (int id, [FromBody] ReporteHorasExtraUpdateDto reporteHorasExtra)
        {
            
            if(id != reporteHorasExtra.Id || reporteHorasExtra == null)
            {
                ModelState.AddModelError("ErrorId", $"El id={id} no es valido");
                return BadRequest(ModelState);
            }

            ReporteHorasExtra reporte = _mapper.Map<ReporteHorasExtra>(reporteHorasExtra);

            await _reporteHoraRepo.Actualizar(reporte);

            return NoContent();
        }

    }
}