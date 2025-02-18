using System.Linq.Expressions;

namespace OnlineStore.Domain.Interfaces;
public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    Expression<Func<T, object>> GroupBy { get; }
    Func<T, object> Projection { get; }

    long PageSize { get; }

    long CurrentPage { get; }
    bool IsPagingEnabled { get; }
}