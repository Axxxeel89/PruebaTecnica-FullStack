using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

public class RepositoryReporteHorasExtra : Repository<ReporteHorasExtra>, IRepositoryReporteHorasExtra
{
    private readonly ApplicationDbContext _context;
    public RepositoryReporteHorasExtra(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ReporteHorasExtra> Actualizar(ReporteHorasExtra reporteHorasExtra)
    {

        _context.reporteHorasExtras.Update(reporteHorasExtra);

        await _context.SaveChangesAsync();

        return reporteHorasExtra;

    }

    public async Task<IEnumerable<ReporteHorasExtra>> ObtenerConRelaciones(string nombre)
    {
        IEnumerable<ReporteHorasExtra> ListarTabla = await _context.reporteHorasExtras
                                                    .Where(c=> c.Empleado!.Nombres.ToLower() == nombre.ToLower())
                                                    .Include(c => c.Empleado).Include(c => c.Estado).ToListAsync();

        return ListarTabla;
    }
}