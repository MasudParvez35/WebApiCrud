using OA.Core;

namespace OA.Data;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> Table { get; }

    Task InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task SaveChangesAsync();
}
