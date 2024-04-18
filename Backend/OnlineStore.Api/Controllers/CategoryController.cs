
using OnlineStore.Application.Features.Categories.Queries;

namespace OnlineStore.Api.Controllers;
public class CategoryController : BaseController
{
    public CategoryController(ISender sender) : base(sender)
    {
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get(long pageSize, long pageNumber)
    {
        return Ok(await _sender.Send(new GetAllCategoryRequest(pageSize, pageNumber)));
    }

    [HttpGet("GetItem")]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        return Ok(await _sender.Send(new GetCategoryByIdRequest(id)));
    }
}