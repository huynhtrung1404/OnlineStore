using Microsoft.AspNetCore.Authorization;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Features.Accounts.Commands;
using OnlineStore.Application.Features.Categories.Commands;

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

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] UserInfoDto userInfo)
    {
        return Ok(await Sender.Send(new RefreshTokenRequest(userInfo)));
    }
}