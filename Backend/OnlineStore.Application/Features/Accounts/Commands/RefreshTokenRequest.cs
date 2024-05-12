using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Application.Options;
using OnlineStore.Application.Specifications;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entity;

namespace OnlineStore.Application.Features.Accounts.Commands;
public record RefreshTokenRequest(string refreshToken) : IRequest<ItemResponse<UserInfoDto>>;
public sealed class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, ItemResponse<UserInfoDto>>
{
    private readonly IUserService _userService;
    private readonly IOnlineStoreRepository<UserToken> _userTokenRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtTokenOption _config;
    private readonly IDateTimeService _dateTimeService;
    public RefreshTokenRequestHandler(IUserService userService, IOnlineStoreRepository<UserToken> userToken, IUnitOfWork unitOfWork, IOptionsSnapshot<JwtTokenOption> option, IDateTimeService dateTimeService)
    {
        _userService = userService;
        _userTokenRepository = userToken;
        _unitOfWork = unitOfWork;
        _config = option.Value;
        _dateTimeService = dateTimeService;
    }

    public async Task<ItemResponse<UserInfoDto>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        if (_userService.IsAuthenticated)
            return new();
        var userToken = await _userTokenRepository.GetItemAsync(new UserTokenSpecification(request.refreshToken ?? throw new ArgumentException("Data is invalid"), _dateTimeService.Now))
            ?? throw new UnauthorizedAccessException("Cannot access to account");
        if (userToken.EndDate > DateTime.UtcNow)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Issuer,
                claims: new List<Claim>() {
                    new(ClaimTypes.Role, userToken.Account?.Permission.ToString() ?? string.Empty),
                    new(Variable.Session, userToken.SessionId.ToString()),
                    new(Variable.UserName, userToken.Account?.UserName ?? string.Empty)
                },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signInCredentials
            );
            UserInfoDto response = new()
            {
                UserName = userToken.Account?.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions)
            };
            userToken.Token = response.Token;
            _userTokenRepository.Update(userToken);
            await _unitOfWork.CommitChangesAsync();
            return new(response);
        }
        _userTokenRepository.Remove(userToken);
        await _unitOfWork.CommitChangesAsync();
        return new(new());
    }
}
