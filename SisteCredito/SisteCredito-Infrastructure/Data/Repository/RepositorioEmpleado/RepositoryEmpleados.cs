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
    
}