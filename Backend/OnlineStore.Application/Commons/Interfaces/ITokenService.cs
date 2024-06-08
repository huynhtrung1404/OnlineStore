using OnlineStore.Application.Params;

namespace OnlineStore.Application.Commons.Interfaces;
public interface ITokenService
{
    string GenerateToken(TokenParam tokenParam);
    string GenerateRefreshToken();
}