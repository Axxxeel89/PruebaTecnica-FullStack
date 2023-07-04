using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositoryGeneros _generoRepo;

        public GenerosController(IRepositoryGeneros generoRepo)
        {
            _generoRepo = generoRepo;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ObtenerTodosGeneros()
        {
            return Ok(await _generoRepo.ObtenerTodos());
        }
        
    }
}