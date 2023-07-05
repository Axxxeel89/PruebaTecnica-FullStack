using SisteCredito_Core.Models;

namespace SisteCredito_Core.Dtos.ReporteHoraExtraDto;

public class ReporteHorasExtraRequestDto
{
    public int EmpleadoId { get; set; }
    public DateTime Fecha { get; set; }
    public int HorasExtras { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string MotivoRechazo { get; set; } = string.Empty;
    public int estadoId { get; set; }
    public bool AprobadoPorLider { get; set; }
    public bool AprobadoPorTalentoHumano { get; set; }
    public bool AprobadoPorGerencia { get; set; }

}