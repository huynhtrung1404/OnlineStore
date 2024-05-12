using System.Security.Claims;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OnlineStore.Application.Options;
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
        var session = Guid.NewGuid();
        var listClaims = new List<Claim>() {
                new("UserName", request.Login.UserName),
                new("Role",account.Permission.ToString()),
                new("Session", session.ToString())};
        var token = TokenUtils.GenerateAccessToken(_config.Key, _config.Issuer, listClaims);
        var refreshToken = TokenUtils.GenerateRefreshToken();
        UserInfoDto response = new()
        {
            FirstName = account.Customer?.FirstName,
            LastName = account.Customer?.LastName,
            UserName = request.Login.UserName,
            Token = token,
            RefreshToken = refreshToken
        };
        var userToken = _mapper.Map<UserToken>(response);
        userToken.SessionId = session;
        userToken.RefreshToken = refreshToken;
        userToken.Account = account;
        userToken.EndDate = request.Login.IsKeptLogin ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1);
        await _userTokenRepository.InsertAsync(userToken);
        await _unitOfWork.CommitChangesAsync();
        return new(response);
    }
}