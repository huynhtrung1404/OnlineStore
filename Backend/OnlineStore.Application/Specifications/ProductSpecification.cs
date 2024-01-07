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
}