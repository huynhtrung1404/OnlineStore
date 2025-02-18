using Microsoft.AspNetCore.Authorization;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Accounts.Commands;
using OnlineStore.Application.Features.Accounts.Queries;

namespace OnlineStore.Api.Controllers;

[AllowAnonymous]
public class AccountController : BaseController
{

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] AccountDto account)
    {
        return Ok(await Sender.Send(new RegisterAccountRequest(account)));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        return Ok(await Sender.Send(new LoginAccountRequest(login)));
    }

    [HttpPost("callback")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        return Ok(await Sender.Send(new RefreshTokenRequest(refreshToken)));
    }

    [Authorize]
    [HttpGet("UserInfo")]
    public async Task<IActionResult> GetUserInfo()
    {
        return Ok(await Sender.Send(new GetUserInfoRequest()));
    }
}