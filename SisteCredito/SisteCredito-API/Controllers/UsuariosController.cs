using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisteCredito_Core.Dtos.UsuariosDto;
using SisteCredito_Infrastructure.Data.Repository.RepositorioUsuarios;

namespace SisteCredito_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositoryUsuarios _userRepo;

        public UsuariosController(IRepositoryUsuarios userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioResponseDto>> Login ([FromBody] UsuarioLoginDto request)
        {
            return await _userRepo.LoginUser(request);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<UsuarioResponseDto>> Registrar ([FromBody] UsuarioRegisterDto request)
        {
            return await _userRepo.RegisterUser(request);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioResponseDto>> DevolverUsuario() //->Tendriamos los datos del usuario.
        {
            return await _userRepo.GetUsuario();
        }
    }
}