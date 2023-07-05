using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioLideres;

public interface IRepositoryLideres : IRepository<Lideres>
{
    Task<Lideres> Actualizar(Lideres lideres);
    Task<IEnumerable<Lideres>> DDLLideres();
}