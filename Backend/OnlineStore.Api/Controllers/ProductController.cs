using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Products.Commands;
using OnlineStore.Application.Features.Products.Queries;

namespace OnlineStore.Api.Controllers;
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> GetAllProduct() =>
        Ok(await _sender.Send(new GetAllProductRequest()));

    [HttpPost("AddNewProduct")]
    public async Task<IActionResult> AddNewProduct([FromBody] ProductDto product)
    {
        await _sender.Send(new AddNewProductRequest(product));
        return Ok();
    }
}