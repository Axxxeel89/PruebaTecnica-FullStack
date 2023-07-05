using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioLideres;

public class RepositoryLideres : Repository<Lideres>, IRepositoryLideres
{
    private readonly ApplicationDbContext _context;
    public RepositoryLideres(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Lideres> Actualizar(Lideres lideres)
    {

        _context.Lideres.Update(lideres);

        await _context.SaveChangesAsync();

        return lideres;
    }

    public async Task<IEnumerable<Lideres>> DDLLideres()
    {
        IEnumerable<Lideres> ddlLideres = await _context.Lideres.Select(c => new Lideres{
            Id = c.Id,
            Nombres = c.Nombres
        }).ToListAsync();

        return ddlLideres;
    }
    
}