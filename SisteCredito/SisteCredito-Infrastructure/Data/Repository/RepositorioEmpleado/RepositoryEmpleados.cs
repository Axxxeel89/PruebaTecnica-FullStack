using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioEmpleado;

public class RepositoryEmpleados : Repository<Empleados>, IRepositoryEmpleados
{
    private readonly ApplicationDbContext _context;
    public RepositoryEmpleados(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Empleados> Actualizar(Empleados empleados)
    {

        _context.Empleados.Update(empleados);

        await _context.SaveChangesAsync();

        return empleados;
    }

    public async Task<IEnumerable<Empleados>> SelectEmpleados()
    {
        IEnumerable<Empleados> ddlEmpleados = await _context.Empleados.Select(c => new Empleados {
            Id= c.Id,
            Nombres = $"{c.Nombres} {c.Apellidos}"
        }).ToListAsync();
        
        return ddlEmpleados;
    }
    
}