using OnlineStore.Application.Commons.Specifications;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Specification;
public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(Guid productId) : base(x => x.Id.Equals(productId))
    {
    }

    public ProductSpecification(string productName) : base(x => x.Name.Contains(productName))
    {
    }

    public ProductSpecification(long pageSize, long pageNumber, bool isIncludedCategory = false) : base(x => x.StockUnit > 0)
    {
        ApplyPaging(pageSize, pageNumber);
        ApplyOrderBy(x => x.CreatedDateTime);
        if (isIncludedCategory)
        {
            AddInclude(x => x.Categories);
        }
    }

    public ProductSpecification() : base(x => x.StockUnit > 0)
    {
        ApplyOrderBy(x => x.CreatedDateTime);
    }
}