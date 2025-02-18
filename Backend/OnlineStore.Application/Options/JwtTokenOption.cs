namespace OnlineStore.Application.Options;
public class JwtTokenOption
{
    public string Key { get; set; } = default!;
    public string Issuer { get; set; } = default!;
}