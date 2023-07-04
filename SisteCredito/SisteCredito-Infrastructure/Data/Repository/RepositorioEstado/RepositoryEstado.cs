using Microsoft.EntityFrameworkCore;
using SisteCredito_Core.Models;
using SisteCredito_Infrastructure.Data.Repository.RepositorioEstado;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioEstado;

public class RepositoryEstado : Repository<Estado>, IRepositoryEstado
{
    private readonly ApplicationDbContext _context;
    public RepositoryEstado(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Estado>> SelectEstado()
    {
        IEnumerable<Estado> ddlEstado = await _context.Estados.ToListAsync();
        
        return ddlEstado;
    }
    
}