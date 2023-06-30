using System.ComponentModel.DataAnnotations;

namespace SisteCredito_Core.Models;

public class Generos
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    
}