using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEmpleado;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEstado;
using SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;
using SisteCredito_Infrastructure.Data.Repository.RepositorioLideres;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodosUtilitariosController : ControllerBase
    {

        private readonly IRepositoryGeneros _generoRepo;
        private readonly IRepositoryAreas _areasRepo;
        private readonly IRepositoryEmpleados _empleRepo;
        private readonly IRepositoryEstado _estadoRepo;
        private readonly IRepositoryLideres _lideresRepo;

        public MetodosUtilitariosController(
            IRepositoryGeneros generoRepo,
            IRepositoryAreas areasRepo,
            IRepositoryEmpleados empleRepo,
            IRepositoryEstado estadoRepo,
            IRepositoryLideres lideresRepo
            )
        {
            _generoRepo = generoRepo;
            _areasRepo = areasRepo;
            _empleRepo = empleRepo;
            _estadoRepo = estadoRepo;
            _lideresRepo = lideresRepo;
        }



        
        [HttpGet]
        [Route("DDLGeneros")]
        public async Task<IActionResult> DDLGeneros()
        {
            var selectGeneros = await _generoRepo.SelectGeneros();

            return Ok(selectGeneros);

        }

        [HttpGet]
        [Route("DDLAreas")]
        public async Task<IActionResult> DDLAreas()
        {
            var selectAreas = await _areasRepo.SelectAreas();

            return Ok(selectAreas);

        }

        [HttpGet]
        [Route("DDLEmpleados")]
        public async Task<IActionResult> DDLEmpleados()
        {
            var selectEmpleados = await _empleRepo.SelectEmpleados();

            return Ok(selectEmpleados);
        }

        [HttpGet]
        [Route("DDLEstadosReporte")]
        public async Task<IActionResult> DDLEstadosReporte()
        {
            var selectEstadoReporte = await _estadoRepo.SelectEstado();

            return Ok(selectEstadoReporte);
        }

        [HttpGet]
        [Route("DDLLideres")]
        public async Task<IActionResult> DDLLideres()
        {
            var selectLideres = await _lideresRepo.DDLLideres();

            return Ok(selectLideres);
        }

    }
}