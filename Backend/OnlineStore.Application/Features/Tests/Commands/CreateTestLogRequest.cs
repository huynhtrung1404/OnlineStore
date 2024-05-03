
using Microsoft.Extensions.Logging;

namespace OnlineStore.Application.Tests.Commands;
public record CreateTestLogRequest(string ApplicationName, string Detail, LogLevel LogLevel) : IRequest;
public sealed class CreateTestLogRequestHandler : IRequestHandler<CreateTestLogRequest>
{
    private readonly ILogger _logger;

    public CreateTestLogRequestHandler(ILoggerFactory logger)
    {
        _logger = logger.CreateLogger("CustomLog.LogLocal");
    }

    public async Task Handle(CreateTestLogRequest request, CancellationToken cancellationToken)
    {
        await Task.Run(()
                => _logger.Log(request.LogLevel, $"Trung log info for {request.ApplicationName} : {request.Detail}"));
    }
}