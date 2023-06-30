using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisteCredito_Core.Models;

public class Empleados
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100, ErrorMessage ="El valor maximo es 100 caracteres")]
    public string Nombres { get; set; } = String.Empty;

    [Required]
    [StringLength(100, ErrorMessage ="El valor maximo es 100 caracteres")]
    public string Apellidos { get; set; } = String.Empty;
    public DateTime FechaNacimiento { get; set; }
    [Required]
    public DateTime FechaIngreso { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El valor debe estar en el rango válido")]
    public int GeneroId { get; set; }
    
    [Required]
    [StringLength(100, ErrorMessage ="El valor maximo es 100 caracteres")]
    public string Cargo { get; set; } = String.Empty;
    public string Mail { get; set; } = String.Empty;
    public int AreasId { get; set; }
    public int LiderId { get; set; }

    [ForeignKey("LiderId")]
    public virtual Lideres? Lideres {get; set;} 

    [ForeignKey("AreasId")]
    public virtual Areas? Areas {get; set;} 

    [ForeignKey("GeneroId")]
    public virtual Generos? Generos {get; set;} 
}