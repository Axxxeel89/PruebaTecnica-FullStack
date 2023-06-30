using SisteCredito_Core.Models;

namespace SisteCredito_Core.Dtos.EmpleadosDto;

public class EmpleadosResponseDto
{
    public string Id { get; set; } = String.Empty;
    public string Nombres { get; set; } = String.Empty;
    public string Apellidos { get; set; } = String.Empty;
    public string FechaNacimiento { get; set; } = String.Empty;
    public string FechaIngreso { get; set; } = String.Empty;
    public string FechaRetiro { get; set; } = String.Empty;
    public string GeneroId { get; set; } = String.Empty;
    public string Cargo { get; set; } = String.Empty;
    public bool UsuarioHabilitado { get; set; }
    public string Mail { get; set; } = String.Empty;
    public string AreasId { get; set; } = String.Empty;
    public string LiderId { get; set; } = String.Empty;

    public virtual Lideres? Lideres {get; set;} 
    public virtual Areas? Areas {get; set;} 
    public virtual Generos? Generos {get; set;} 
}
