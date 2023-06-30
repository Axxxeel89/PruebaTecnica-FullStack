namespace SisteCredito_Core.Dtos.UsuariosDto;

public class UsuarioRegisterDto
{
    public string? Nombres { get; set; } 
    public string? Apellidos { get; set; }
    public string? Rol { get; set; } 
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }

}