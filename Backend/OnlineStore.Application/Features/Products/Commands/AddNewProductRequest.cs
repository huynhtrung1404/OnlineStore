using MediatR;
using OnlineStore.Application.Commons.Interfaces;
using OnlineStore.Application.DTOs;

namespace OnlineStore.Application.Features.Products.Commands;
public record AddNewProductRequest(ProductDto Product) : IRequest
{ }

public sealed class AddNewProductRequestHandler : IRequestHandler<AddNewProductRequest>
{
    private readonly IProductService _productService;

    public AddNewProductRequestHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Handle(AddNewProductRequest request, CancellationToken cancellationToken)
    {
        await _productService.AddProductAsync(request.Product);
    }
}