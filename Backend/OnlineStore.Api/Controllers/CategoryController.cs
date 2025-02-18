
using Microsoft.AspNetCore.Authorization;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Categories.Commands;
using OnlineStore.Application.Features.Categories.Queries;

namespace OnlineStore.Api.Controllers;
[Authorize]
public class CategoryController : BaseController
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> Get(long pageSize, long pageNumber)
    {
        return Ok(await Sender.Send(new GetAllCategoryRequest(pageSize, pageNumber)));
    }

    [HttpGet("GetItem")]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        return Ok(await Sender.Send(new GetCategoryByIdRequest(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CategoryDto category)
    {
        return Ok(await Sender.Send(new AddNewCategoryRequest(category)));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] CategoryDto category)
    {
        return Ok(await Sender.Send(new UpdateCategoryRequest(category)));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await Sender.Send(new RemoveCategoryRequest(id)));
    }
}