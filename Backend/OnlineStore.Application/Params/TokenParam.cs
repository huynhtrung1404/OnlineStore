namespace OnlineStore.Application.Params;
public record TokenParam(string UserName, string Permission, Guid SessionId);