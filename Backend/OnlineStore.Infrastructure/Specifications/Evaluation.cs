using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Infrastructure.Specifications;
public static class Evaluation<T> where T : class
{
    public static async Task<IEnumerable<T>> GetQueryAsync(IQueryable<T> query, ISpecification<T> specification)
    {
        var result = GetQuery(query, specification);
        return await result.ToListAsync();
    }

    public static async Task<T?> GetQueryItemAsync(IQueryable<T> query, ISpecification<T> specification)
    {
        if (specification is null)
        {
            return await query.FirstOrDefaultAsync();
        }
        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }
        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        return await query.FirstOrDefaultAsync();
    }
    public static async Task<int> CountAsync(IQueryable<T> query, ISpecification<T> specification)
    {
        var result = GetQuery(query, specification);
        return await result.CountAsync();
    }

    private static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> specification)
    {
        if (specification is null)
        {
            return query;
        }

        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        if (specification.IsPagingEnabled)
        {
            query = query.Skip((int)(specification.CurrentPage - 1) * (int)specification.PageSize).Take((int)specification.PageSize);
        }
        if (specification.OrderBy is not null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        if (specification.OrderByDescending is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }
        if (specification.Projection is not null)
        {
            query = (IQueryable<T>)query.Select(specification.Projection);
        }
        return query;
    }
}