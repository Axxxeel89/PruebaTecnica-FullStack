using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisteCredito_Core.Models;

public class ReporteHorasExtra
{
    [Key]
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime Fecha { get; set; }
    [Required]
    public int HorasExtras { get; set; }
    [Required]
    public string Motivo { get; set; } = string.Empty;
    [Required]
    public string MotivoRechazo { get; set; } = string.Empty;
    public int estadoId { get; set; }
    public bool AprobadoPorLider { get; set; }
    public bool AprobadoPorTalentoHumano { get; set; }
    public bool AprobadoPorGerencia { get; set; }

    [ForeignKey("EmpleadoId")]
    public virtual Empleados? Empleado { get; set; }

    [ForeignKey("estadoId")]
    public virtual Estado? Estado { get; set; }
}