namespace OnlineStore.Api.Controllers;
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected readonly ISender Sender;

    public BaseController(ISender sender) =>
        Sender = sender;
}