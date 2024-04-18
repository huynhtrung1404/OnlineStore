using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Domain.Commons.Interface;
public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(Guid id);
    Task InsertAsync(T entity);
    Task InsertManyAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(T entities);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetListAsync(ISpecification<T> specification);
    Task<T?> GetItemAsync(ISpecification<T> specification);
    Task<long> CountAsync(ISpecification<T> specification);
}