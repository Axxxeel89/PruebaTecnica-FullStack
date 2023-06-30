using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisteCredito_Core.Models;

public class ReporteNovedad
{
    [Key]
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime FechaDesvinculacion { get; set; }
    public decimal ValoresHoraExtra { get; set; }

    [ForeignKey("EmpleadoId")]
    public virtual Empleados? Empleados { get; set; }
}