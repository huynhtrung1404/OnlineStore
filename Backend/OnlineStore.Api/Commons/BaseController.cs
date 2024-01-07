namespace OnlineStore.Api.Controllers;
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected readonly ISender _sender;

    public BaseController(ISender sender)
    {
        _sender = sender;
    }
}