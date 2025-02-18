using OnlineStore.Application.Commons.Specifications;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Specifications;
public class CategorySpecification : BaseSpecification<Category>
{
    public CategorySpecification(long pageSize, long pageNumber) : base(x => x.IsEnabled)
    {
        ApplyPaging(pageSize, pageNumber);
        ApplyOrderBy(x => x.CreatedDateTime);
    }
    public CategorySpecification(Guid id) : base(x => x.Id.Equals(id)) { }
    public CategorySpecification() : base(x => x.IsEnabled)
    {
        ApplyOrderBy(x => x.CreatedDateTime);
    }
    public CategorySpecification(IEnumerable<Guid> categoryIds) : base(x => categoryIds.Contains(x.Id))
    {

    }
}