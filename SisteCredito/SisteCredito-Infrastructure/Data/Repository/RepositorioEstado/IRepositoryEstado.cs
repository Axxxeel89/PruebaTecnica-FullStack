using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioEstado;

public interface IRepositoryEstado : IRepository<Estado>
{
    Task<IEnumerable<Estado>> SelectEstado();
}