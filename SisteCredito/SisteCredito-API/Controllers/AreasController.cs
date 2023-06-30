using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Core.Dtos.EmpleadosDto;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IRepositoryAreas _areasRepo;

        public AreasController(IRepositoryAreas areasRepo)
        {
            _areasRepo = areasRepo;
        }

        [HttpGet]
        public async Task<ActionResult<EmpleadosResponseDto>> ListarEmpleados()
        {
            return Ok(await _areasRepo.ObtenerTodos());
        }
    }
}