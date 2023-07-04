using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioGeneros;

public class RepositoryGeneros : Repository<Generos>, IRepositoryGeneros
{
    private readonly ApplicationDbContext _context;
    public RepositoryGeneros(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Generos> Actualizar(Generos generos)
    {

        _context.Generos.Update(generos);

        await _context.SaveChangesAsync();

        return generos;

    }

    public async Task<IEnumerable<Generos>> SelectGeneros()
    {
        IEnumerable<Generos> ddlGeneros = await _context.Generos.ToListAsync();
        
        return ddlGeneros;
    }

}