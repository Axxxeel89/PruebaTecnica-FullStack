using SisteCredito_Core.Dtos.UsuariosDto;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioUsuarios;

public interface IRepositoryUsuarios
{
    Task<UsuarioResponseDto> GetUsuario();
    Task<UsuarioResponseDto> LoginUser(UsuarioLoginDto request);
    Task<UsuarioResponseDto> RegisterUser(UsuarioRegisterDto request);
}