using System.Linq.Expressions;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Commons.Specifications;
public class BaseSpecification<T> : ISpecification<T> where T : class
{
    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    public List<string> IncludeStrings { get; } = new List<string>();
    public Expression<Func<T, object>> OrderBy { get; private set; } = default!;
    public Expression<Func<T, object>> OrderByDescending { get; private set; } = default!;
    public Expression<Func<T, object>> GroupBy { get; private set; } = default!;
    public Func<T, object> Projection { get; private set; } = default!;

    public long PageSize { get; private set; }
    public long CurrentPage { get; private set; } = 1;
    public bool IsPagingEnabled { get; private set; } = false;

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
    protected virtual void ApplyPaging(long pageSize, long currentPage)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        IsPagingEnabled = true;
    }
    protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }

    protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
    {
        GroupBy = groupByExpression;
    }

    protected virtual void ApplyProjection(Func<T, object> projection)
    {
        Projection = projection;
    }

}