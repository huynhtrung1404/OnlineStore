
using Microsoft.Extensions.Logging;

namespace OnlineStore.Application.Tests.Commands;
public record CreateTestLogRequest(string LogName, string Detail, LogLevel LogLevel) : IRequest;
public sealed class CreateTestLogRequestHandler : IRequestHandler<CreateTestLogRequest>
{
    private readonly ILogger _logger;

    public CreateTestLogRequestHandler(ILoggerFactory logger)
    {
        _logger = logger.CreateLogger("OnlineStore.Loging");
    }

    public async Task Handle(CreateTestLogRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow.ToString("G");
        await Task.Run(()
                => _logger.Log(request.LogLevel, $"[{now}]{request.LogName} \n {request.Detail}"));
    }
}