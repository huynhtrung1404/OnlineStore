using MediatR;
using OnlineStore.Application.Commons.Interfaces;

namespace OnlineStore.Application.Features.Products.Commands;
public record RemoveProductRequest(Guid Id) : IRequest
{

}

public sealed class RemoveProductRequestHandler : IRequestHandler<RemoveProductRequest>
{
    private readonly IProductService _productService;

    public RemoveProductRequestHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Handle(RemoveProductRequest request, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(request.Id);
    }
}