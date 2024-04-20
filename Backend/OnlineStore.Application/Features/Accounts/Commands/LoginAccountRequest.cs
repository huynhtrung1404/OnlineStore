using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Specifications;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Entity;
using OnlineStore.Shared.Common.Utilities;

namespace OnlineStore.Application.Features.Accounts.Commands;
public record LoginAccountRequest(LoginDto Login) : IRequest<ItemResponse<UserInfoDto>>
{

}

public sealed class LoginAccountRequestHandler : IRequestHandler<LoginAccountRequest, ItemResponse<UserInfoDto>>
{
    private readonly IOnlineStoreRepository<Account> _accountRepository;
    private readonly IConfiguration _config;
    private readonly IOnlineStoreRepository<UserToken> _userTokenRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public LoginAccountRequestHandler(IOnlineStoreRepository<Account> accountRepository, IConfiguration config, IOnlineStoreRepository<UserToken> userTokenRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _config = config;
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
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]
                                                    ?? throw new ArgumentException("JWT key is null")));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier, request.Login.UserName),
                new Claim(ClaimTypes.Role,"User")
            };
        var token = new JwtSecurityToken(_config["Token:Issuer"],
            _config["Token:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        new JwtSecurityTokenHandler().WriteToken(token);
        UserInfoDto response = new()
        {
            FirstName = account.Customer?.FirstName,
            LastName = account.Customer?.LastName,
            UserName = request.Login.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
        var userToken = _mapper.Map<UserToken>(response);
        userToken.Account = account;
        userToken.EndDate = request.Login.IsKeptLogin ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1);
        await _userTokenRepository.InsertAsync(userToken);
        await _unitOfWork.CommitChangesAsync();
        return new(response);
    }
}