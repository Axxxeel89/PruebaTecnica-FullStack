using SisteCredito_Core.Models;

namespace SisteCredito_Core.Dtos.ReporteHorasExtra;

public class ReporteHorasExtraResquestDto
{
    public string? Id { get; set; }
    public string? EmpleadoId { get; set; }
    public string? Fecha { get; set; }
    public string? HorasExtras { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string MotivoRechazo { get; set; } = string.Empty;
    public EstadoReporteHora Estado { get; set; }
    public bool AprobadoPorLider { get; set; }
    public bool AprobadoPorTalentoHumano { get; set; }
    public bool AprobadoPorGerencia { get; set; }
}