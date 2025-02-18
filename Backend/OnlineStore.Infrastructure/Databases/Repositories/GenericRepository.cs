using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Specifications;

namespace OnlineStore.Infrastructure.Databases.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private DbSet<T> dbSet;
    public GenericRepository(DbContext context)
    {
        _context = context;
        dbSet = context.Set<T>();

    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetListAsync(ISpecification<T> specification)
    {
        return await Evaluation<T>.GetQueryAsync(dbSet, specification);
    }

    public async Task<T?> GetItemAsync(ISpecification<T> specification)
    {
        return await Evaluation<T>.GetQueryItemAsync(dbSet, specification);
    }

    public T? GetById(Guid id)
    {
        return dbSet.Find(id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task InsertAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task InsertManyAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(T entities)
    {
        dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public async Task<long> CountAsync(ISpecification<T> specification) =>
        await Evaluation<T>.CountAsync(dbSet, specification);
}