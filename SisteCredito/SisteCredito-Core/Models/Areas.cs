using System.ComponentModel.DataAnnotations;

namespace SisteCredito_Core.Models;

public class Areas
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public virtual ICollection<Empleados> Empleados {get; set;} = new List<Empleados>(); //--> Relación inversa a empleados

}