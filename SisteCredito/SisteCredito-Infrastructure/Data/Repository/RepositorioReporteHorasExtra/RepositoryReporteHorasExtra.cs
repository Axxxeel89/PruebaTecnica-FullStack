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
        IEnumerable<ReporteHorasExtra> listarTabla = null;

        var empleado = await _context.Empleados                         
                             .FirstOrDefaultAsync(l => l.Nombres.ToLower() == nombre.ToLower() && l.Cargo == "Empleado");

        if (empleado != null)
        {
            listarTabla = await _context.reporteHorasExtras
                                                    .Where(c=> c.Empleado!.Nombres.ToLower() == nombre.ToLower())
                                                    .Include(c => c.Empleado)
                                                    .Include(c => c.Estado)
                                                    .ToListAsync();

            return listarTabla;
        }
        
             listarTabla = await _context.reporteHorasExtras
                                                .Include(c => c.Empleado)
                                                .Include(c => c.Estado)
                                                .ToListAsync();

        return listarTabla!;
    }

    public async Task<IEnumerable<ReporteHorasExtra>> ObtenerFiltradoLider(string nombre)
    {
        IEnumerable<ReporteHorasExtra> listarTabla = null;

        var lider = await _context.Lideres                         
                             .FirstOrDefaultAsync(l => l.Nombres.ToLower() == nombre.ToLower());

        if (lider != null)
        {
            listarTabla = await _context.reporteHorasExtras
                                                    .Where(c=> c.Empleado!.Cargo == "Empleado")
                                                    .Include(c => c.Empleado)
                                                    .Include(c => c.Estado)
                                                    .ToListAsync();

            return listarTabla;
        }

             listarTabla = await _context.reporteHorasExtras
                                                .Include(c => c.Empleado)
                                                .Include(c => c.Estado)
                                                .ToListAsync();
        return listarTabla;
    }

    public async Task<double> ObtenerTotalHorasExtras(string nombre)
    {
          var empleado = await _context.Empleados                         
                             .FirstOrDefaultAsync(l => l.Nombres.ToLower() == nombre.ToLower() && l.Cargo == "Empleado");


            double listarTabla =  _context.reporteHorasExtras
                                                    .Where(c=> c.Empleado!.Nombres.ToLower() == nombre.ToLower() && c.Estado!.Nombre.Contains("Aprobado"))
                                                    .Include(c => c.Empleado)
                                                    .Include(c => c.Estado)
                                                    .Sum( c => c.HorasExtras);

            return listarTabla;
        
    }
}