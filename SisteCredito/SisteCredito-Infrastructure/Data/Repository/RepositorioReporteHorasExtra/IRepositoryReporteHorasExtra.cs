using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

public interface IRepositoryReporteHorasExtra : IRepository<ReporteHorasExtra>
{
    Task<ReporteHorasExtra> Actualizar(ReporteHorasExtra reporteHorasExtra);
}