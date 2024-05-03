using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace OnlineStore.Application.Loggings;
public static class CustomLogging
{
    public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });
}