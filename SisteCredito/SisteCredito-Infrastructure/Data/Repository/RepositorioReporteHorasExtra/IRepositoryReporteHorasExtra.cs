using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

public interface IRepositoryReporteHorasExtra : IRepository<ReporteHorasExtra>
{
    Task<ReporteHorasExtra> Actualizar(ReporteHorasExtra reporteHorasExtra);

    Task<IEnumerable<ReporteHorasExtra>> ObtenerConRelaciones(string nombre);

    Task<IEnumerable<ReporteHorasExtra>> ObtenerFiltradoLider(string nombre);

    Task<double> ObtenerTotalHorasExtras(string nombre);
}