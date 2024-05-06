using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Application.Options;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Specifications;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Entity;
using OnlineStore.Shared.Common.Utilities;

namespace OnlineStore.Application.Features.Accounts.Commands;
public record LoginAccountRequest(LoginDto Login) : IRequest<ItemResponse<UserInfoDto>>;

public sealed class LoginAccountRequestHandler : IRequestHandler<LoginAccountRequest, ItemResponse<UserInfoDto>>
{
    private readonly IOnlineStoreRepository<Account> _accountRepository;
    private readonly JwtTokenOption _config;
    private readonly IOnlineStoreRepository<UserToken> _userTokenRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public LoginAccountRequestHandler(IOnlineStoreRepository<Account> accountRepository,
        IConfiguration config,
        IOnlineStoreRepository<UserToken> userTokenRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IOptionsSnapshot<JwtTokenOption> options)
    {
        _accountRepository = accountRepository;
        _config = options.Value;
        _userTokenRepository = userTokenRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse<UserInfoDto>> Handle(LoginAccountRequest request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository
            .GetItemAsync(new AccountSpecification(request.Login.UserName, Utilities.EncryptSHA512(request.Login.Password)));
        if (account is null)
            throw new ArgumentNullException("Account is null");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var session = Guid.NewGuid();
        var tokenOptions = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Issuer,
            claims: new List<Claim>() {
                new("UserName", request.Login.UserName),
                new("Role",account.Permission.ToString()),
                new("Session", session.ToString())
            },
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signInCredentials
        );

        UserInfoDto response = new()
        {
            FirstName = account.Customer?.FirstName,
            LastName = account.Customer?.LastName,
            UserName = request.Login.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions)
        };
        var userToken = _mapper.Map<UserToken>(response);
        userToken.SessionId = session;
        userToken.Account = account;
        userToken.EndDate = request.Login.IsKeptLogin ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1);
        await _userTokenRepository.InsertAsync(userToken);
        await _unitOfWork.CommitChangesAsync();
        return new(response);
    }
}