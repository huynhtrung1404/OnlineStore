using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Infrastructure.Specifications;
public static class Evaluation<T> where T : class
{
    public static async Task<IEnumerable<T>> GetQueryAsync(IQueryable<T> query, ISpecification<T> specification)
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

        if (specification.OrderBy is not null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        if (specification.OrderByDescending is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }
        if (specification.IsPagingEnabled)
        {
            query = query.Skip((specification.CurrentPage - 1) * specification.PageSize).Take(specification.PageSize);
        }

        return await query.ToListAsync();
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
}