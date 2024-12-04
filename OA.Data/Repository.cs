using Microsoft.EntityFrameworkCore;
using OA.Core;

namespace OA.Data;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public IQueryable<T> Table => _entities;

    public async Task DeleteAsync(T entity)
    {
        _entities.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FirstOrDefaultAsync(e => e.Id == id);    
    }

    public async Task InsertAsync(T entity)
    {
        await _entities.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await SaveChangesAsync();
    }
}
