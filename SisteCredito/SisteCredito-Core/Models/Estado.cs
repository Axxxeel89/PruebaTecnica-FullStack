using System.ComponentModel.DataAnnotations;

namespace SisteCredito_Core.Models;

public class Estado{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}