using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Dtos.UsuariosDto;
using SisteCredito_Core.Models;
using SisteCredito_Core.Token;
using SisteCredito_Infrastructure.Middlewares;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioUsuarios;

public class RepositoryUsuarios : IRepositoryUsuarios
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuarios> _userManager;
    private readonly SignInManager<Usuarios> _signInManager;
    private readonly IJwtGenerador _jwtGenerador;
    private readonly IUsuarioSesion _usuarioSesion;

    public RepositoryUsuarios
    (
        ApplicationDbContext context,
        UserManager<Usuarios> userManager,
        SignInManager<Usuarios> signInManager,
        IJwtGenerador jwtGenerador,
        IUsuarioSesion usuarioSesion
    )
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerador = jwtGenerador;
        _usuarioSesion = usuarioSesion;
        
    }

    private UsuarioResponseDto TransformarUsuarioToDto(Usuarios usuario)
    {
        return new UsuarioResponseDto {
            Id= usuario.Id,
            Nombre = usuario.Nombres,
            Apellido = usuario.Apellidos,
            Rol = usuario.Rol,
            Email = usuario.Email,
            UserName = usuario.UserName,
            Token = _jwtGenerador.CrearToken(usuario)
        };

    }

    public async Task<UsuarioResponseDto> GetUsuario()
    {
        var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

        if(usuario is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new {mensaje = "El usuario del token no existe en la base de datos"}
            );
        }

        return TransformarUsuarioToDto(usuario!);
    }

    public async Task<UsuarioResponseDto> LoginUser(UsuarioLoginDto request)
    {
        var usuario = await _userManager.FindByEmailAsync(request.Email!);

        if(usuario is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new {mensaje = "El email del usuario no existe en la Base de datos."}
            );
        }

        var resultado = await _signInManager.CheckPasswordSignInAsync(usuario!, request.Password!, false);
        
        if(resultado.Succeeded)
        {
            return TransformarUsuarioToDto(usuario!);
        }
        
        throw new MiddlewareException(
            HttpStatusCode.Unauthorized,
            new {mensaje = "Las credenciales no son correctas"}
        );
                
        
    }

    public async Task<UsuarioResponseDto> RegisterUser(UsuarioRegisterDto request)
    {
         //Validamos que Email del request no exista en la base de datos
        var existeMail = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();

        if(existeMail)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new {mensaje = "El E-mail existe en la base de datos."}
            );
        }

        var existeUserName = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync();

        if(existeUserName)
        {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new {mensaje = "El Username ya existe en la base de datos."}
            );
        }


        var usuario = new Usuarios {
            Nombres = request.Nombres!,
            Apellidos = request.Apellidos!,
            Rol = request.Rol!,
            Email = request.Email,
            UserName = request.UserName
        };

        var resultado = await _userManager.CreateAsync(usuario, request.Password!);
        
        if(resultado.Succeeded)
        {
            return TransformarUsuarioToDto(usuario);
        }

        // Manejo de errores

        var errores = resultado.Errors.Select(e => e.Description).ToList();

        throw new MiddlewareException(
            HttpStatusCode.Unauthorized,
            new { mensaje = "No se pudo registrar el usuario", errores }
        );

    }
}
