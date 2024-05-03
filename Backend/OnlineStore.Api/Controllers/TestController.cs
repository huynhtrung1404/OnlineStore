
using Microsoft.AspNetCore.Authorization;

namespace OnlineStore.Api.Controllers;
[AllowAnonymous]
public class TestController : BaseController
{
    public TestController(ISender sender) : base(sender)
    {
    }
    [HttpGet("GetData")]
    public async Task<IActionResult> GetData()
    {
        return Ok(await Task.FromResult(true));
    }
}