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
    private readonly IDateTimeService _dateTimeService;
    private readonly ITokenService _tokenService;
    public RefreshTokenRequestHandler(IUserService userService, IOnlineStoreRepository<UserToken> userToken, IUnitOfWork unitOfWork, IDateTimeService dateTimeService, ITokenService tokenService)
    {
        _userService = userService;
        _userTokenRepository = userToken;
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
        _tokenService = tokenService;
    }

    public async Task<ItemResponse<UserInfoDto>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        if (_userService.IsAuthenticated)
            return new();
        var userToken = await _userTokenRepository.GetItemAsync(new UserTokenSpecification(request.refreshToken ?? throw new ArgumentException("Data is invalid"), _dateTimeService.Now))
            ?? throw new UnauthorizedAccessException("Cannot access to account");
        if (userToken.EndDate > _dateTimeService.Now)
        {
            var refreshToken = _tokenService.GenerateRefreshToken();
            UserInfoDto response = new()
            {
                RefreshToken = refreshToken,
                UserName = userToken.Account?.UserName,
                Token = _tokenService.GenerateToken(new(userToken.Account?.UserName ?? string.Empty, userToken.Account?.Permission.ToString() ?? string.Empty, userToken.SessionId))
            };
            userToken.Token = response.Token;
            userToken.RefreshToken = refreshToken;
            _userTokenRepository.Update(userToken);
            await _unitOfWork.CommitChangesAsync();
            return new(response);
        }
        _userTokenRepository.Remove(userToken);
        await _unitOfWork.CommitChangesAsync();
        return new(new());
    }
}