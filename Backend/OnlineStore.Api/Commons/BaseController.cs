namespace OnlineStore.Api.Controllers;
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private ISender? _sender;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();

}