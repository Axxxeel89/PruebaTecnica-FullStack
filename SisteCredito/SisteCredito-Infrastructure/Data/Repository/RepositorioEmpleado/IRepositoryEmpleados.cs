using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioEmpleado;

public interface IRepositoryEmpleados : IRepository<Empleados>
{
    Task<Empleados> Actualizar(Empleados empleados);
}