using OnlineStore.Domain.Entity;

namespace OnlineStore.Application.Features.Accounts.Commands;
public record RefreshTokenRequest(string RefreshToken) : IRequest<ItemResponse<UserInfoDto>>;
public sealed class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, ItemResponse<UserInfoDto>>
{
    private readonly IUserService _userService;
    private readonly IOnlineStoreRepository<UserToken> _userTokenRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeService _dateTimeService;
    private readonly ITokenService _tokenService;
    private readonly ICookieService _cookieService;
    public RefreshTokenRequestHandler(IUserService userService, IOnlineStoreRepository<UserToken> userToken, IUnitOfWork unitOfWork, IDateTimeService dateTimeService, ITokenService tokenService, ICookieService cookieService)
    {
        _userService = userService;
        _userTokenRepository = userToken;
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
        _tokenService = tokenService;
        _cookieService = cookieService;
    }

    public async Task<ItemResponse<UserInfoDto>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        if (_userService.IsAuthenticated)
            return new();
        var userToken = await _userTokenRepository.GetItemAsync(new UserTokenSpecification(request.RefreshToken ?? throw new ArgumentException("Data is invalid"), _dateTimeService.Now))
            ?? throw new UnauthorizedAccessException("Cannot access to account");
        if (userToken.EndDate > _dateTimeService.Now)
        {
            var refreshToken = _tokenService.GenerateRefreshToken();
            var accessToken = _tokenService.GenerateToken(new(userToken.Account?.UserName!, userToken.Account?.Permission.ToString()!, userToken.SessionId));
            _cookieService.Save(Variable.RefreshToken, refreshToken);
            _cookieService.Save(Variable.AccessToken, accessToken);
            UserInfoDto response = new()
            {
                UserName = userToken.Account?.UserName,
            };
            userToken.Token = accessToken;
            userToken.RefreshToken = refreshToken;
            _userTokenRepository.Update(userToken);
            await _unitOfWork.CommitChangesAsync();
            return new(response);
        }
        _userTokenRepository.Remove(userToken);
        await _unitOfWork.CommitChangesAsync();
        _cookieService.RemoveAll();
        return new(new());
    }
}