
using Microsoft.Extensions.Logging;

namespace OnlineStore.Application.Features.Tests.Behaviors;
public class LoggingBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviors(ILogger<LoggingBehaviors<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        var response = await next();
        _logger.LogInformation($"Handled {typeof(TResponse).Name}");

        return response;
    }
}