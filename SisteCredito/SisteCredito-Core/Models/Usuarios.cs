using Microsoft.AspNetCore.Identity;

namespace SisteCredito_Core.Models;

public class Usuarios : IdentityUser
{
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;

}