using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SisteCredito_Infrastructure.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    internal DbSet<T> dbSet;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        this.dbSet = context.Set<T>();
    }

    public async Task Crear(T entidad)
    {
        await dbSet.AddAsync(entidad);
        await Grabar();
    }

    public async Task Grabar()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<T> Obtener(Expression<Func<T, bool>>? Filtro = null, bool tracked = true)
    {
        //Lo primero vamos a recibir una variable IQueryable
        IQueryable<T> query = dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        //-> Si filtro es diferente a null entonces quiere decir que nos envian una expresion lambda
        if (Filtro != null)
        {
            query = query.Where(Filtro); //->Query siempre trabaja con una expression Linq
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? Filtro = null)
    {
        //Lo primero vamos a recibir una variable IQueryable
        IQueryable<T> query = dbSet;

        //-> Si filtro es diferente a null entonces quiere decir que nos envian una expresion lambda
        if (Filtro != null)
        {
            query = query.Where(Filtro); //->Query siempre trabaja con una expression Linq
        }

        return await query.ToListAsync();
    }

    public async Task Remover(T entidad)
    {
        dbSet.Remove(entidad);
        await Grabar();
    }
}
