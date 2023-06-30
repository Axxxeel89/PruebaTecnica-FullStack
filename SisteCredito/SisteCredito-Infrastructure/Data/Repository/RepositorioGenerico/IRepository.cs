using System.Linq.Expressions;

namespace SisteCredito_Infrastructure.Data.Repository;

public interface IRepository<T> where T : class 
{
    Task Crear(T entidad);
    Task<List<T>> ObtenerTodos (Expression<Func<T,bool>> ? Filtro = null);
    Task<T> Obtener(Expression<Func<T, bool>>? Fitro = null, bool tracked=true);
    Task Remover(T entidad);
    Task Grabar();
}