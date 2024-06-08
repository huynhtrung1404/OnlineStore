using Microsoft.AspNetCore.Authorization;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Products.Commands;
using OnlineStore.Application.Features.Products.Queries;

namespace OnlineStore.Api.Controllers;
[Authorize]
public class ProductController : BaseController
{

    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> GetAllProduct(long pageSize, long pageNumber) =>
        Ok(await Sender.Send(new GetAllProductRequest(pageSize, pageNumber)));

    [HttpGet("GetProductById")]
    public async Task<IActionResult> GetProductById(Guid id) =>
        Ok(await Sender.Send(new GetProductByIdRequest(id)));

    [HttpPost("AddNewItem")]
    public async Task<IActionResult> AddNewProduct([FromBody] ProductDto product)
    {
        await Sender.Send(new AddNewProductRequest(product));
        return Ok();
    }

    [HttpPut("UpdateItem")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product) =>
        Ok(await Sender.Send(new UpdateProductRequest(product)));

    [HttpDelete("RemoveItem")]
    public async Task<IActionResult> RemoveProduct(Guid id)
    {
        await Sender.Send(new RemoveProductRequest(id));
        return Ok();
    }

    [HttpPost("AddCategoryToProduct")]
    public async Task<IActionResult> AddCategoryToProduct([FromBody] CategoryToProductDto detail)
    {
        await Sender.Send(new AddCategoryToProductRequest(detail));
        return Ok();
    }
}