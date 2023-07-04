using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;

public interface IRepositoryGeneros : IRepository<Generos>
{
    Task<Generos> Actualizar(Generos generos);
    Task<IEnumerable<Generos>> SelectGeneros();
}