using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<Usuarios>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Empleados> Empleados { get; set; }
    public DbSet<Lideres> Lideres { get; set; }
    public DbSet<Areas> Areas { get; set; }
    public DbSet<Generos> Generos { get; set; }
    public DbSet<ReporteHorasExtra> reporteHorasExtras { get; set; }
    public DbSet<Estado> Estados {get; set;}

}
