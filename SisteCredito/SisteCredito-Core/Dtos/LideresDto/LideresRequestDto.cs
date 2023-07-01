namespace SisteCredito_Core.Dtos.LideresDto;

public class LideresRequestDto
{
    public string Nombres { get; set; } = String.Empty;
    public string Apellidos { get; set; } = String.Empty;
    public string? FechaNacimiento { get; set; }
    public string? FechaIngreso { get; set; }
    public string? GeneroId { get; set; }
    public string Cargo { get; set; } = String.Empty;
    public string Mail { get; set; } = String.Empty;
    public int AreasId { get; set; }
}