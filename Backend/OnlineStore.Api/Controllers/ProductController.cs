using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Products.Commands;
using OnlineStore.Application.Features.Products.Queries;

namespace OnlineStore.Api.Controllers;
[Route("api/[controller]")]
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

    [HttpGet("GetProductById")]
    public async Task<IActionResult> GetProductById(Guid id) => Ok(await _sender.Send(new GetProductByIdRequest(id)));

    [HttpPost("AddNewItem")]
    public async Task<IActionResult> AddNewProduct([FromBody] ProductDto product)
    {
        await _sender.Send(new AddNewProductRequest(product));
        return Ok();
    }

    [HttpPut("UpdateItem")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product) =>
        Ok(await _sender.Send(new UpdateProductRequest(product)));

    [HttpDelete("RemoveItem")]
    public async Task<IActionResult> RemoveProduct(Guid id)
    {
        await _sender.Send(new RemoveProductRequest(id));
        return Ok();
    }
}