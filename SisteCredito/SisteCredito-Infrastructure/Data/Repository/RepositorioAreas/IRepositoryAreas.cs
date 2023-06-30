using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

public interface IRepositoryAreas : IRepository<Areas>
{
    Task<Areas> Actualizar(Areas areas);
}