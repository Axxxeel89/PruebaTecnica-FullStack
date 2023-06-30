using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Core.Dtos.EmpleadosDto;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEmpleado;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepositoryEmpleados _empRepo;

        public EmpleadosController(IRepositoryEmpleados empRepo)
        {
            _empRepo = empRepo;
        }

        [HttpGet]
        public async Task<ActionResult<EmpleadosResponseDto>> ListarEmpleados()
        {
            return Ok(_empRepo.ObtenerTodos());
        }
    }
}