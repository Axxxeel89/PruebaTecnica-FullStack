using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;
using SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodosUtilitariosController : ControllerBase
    {

        private readonly IRepositoryGeneros _generoRepo;
        private readonly IRepositoryAreas _areasRepo;

        public MetodosUtilitariosController(
            IRepositoryGeneros generoRepo,
            IRepositoryAreas areasRepo
            )
        {
            _generoRepo = generoRepo;
            _areasRepo = areasRepo;
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
    }
}