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
    
}