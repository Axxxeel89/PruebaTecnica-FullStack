using SisteCredito_Core.Models;

namespace SisteCredito_Infrastructure.Data.Repository.RepositorioAreas;

public class RepositoryAreas : Repository<Areas>, IRepositoryAreas
{
    private readonly ApplicationDbContext _context;
    public RepositoryAreas(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Areas> Actualizar(Areas areas)
    {

        _context.Areas.Update(areas);

        await _context.SaveChangesAsync();

        return areas;

    }
    
}