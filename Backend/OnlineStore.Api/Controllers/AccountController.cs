

using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Accounts.Commands;

namespace OnlineStore.Api.Controllers;
public class AccountController : BaseController
{
    public AccountController(ISender sender) : base(sender)
    {
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] AccountDto account)
    {
        return Ok(await _sender.Send(new RegisterAccountRequest(account)));
    }

}