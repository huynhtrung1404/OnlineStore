using System.Text;
using OnlineStore.Application.Tests.Commands;

namespace OnlineStore.Api.TestMiddleware;
public class TestMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ISender _sender;

    public TestMiddleware(RequestDelegate next, ISender sender)
    {
        _next = next;
        _sender = sender;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            var requestContent = new StringBuilder();
            requestContent.AppendLine($"Protocol: {httpContext.Request.Protocol}");
            requestContent.AppendLine($"Scheme: {httpContext.Request.Scheme}");
            requestContent.AppendLine($"Method: {httpContext.Request.Method}");
            requestContent.AppendLine($"PathBase: {httpContext.Request.PathBase}");
            requestContent.AppendLine($"Path: {httpContext.Request.Path}");
            await _sender.Send(new CreateTestLogRequest("Log Request", requestContent.ToString(), LogLevel.Information));
        }
        catch (Exception ex)
        {
            await _sender.Send(new CreateTestLogRequest("Log Error", $"{httpContext.Request.Path} - {ex.Message}", LogLevel.Error));
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsync("Something went wrong, please try again later");
            throw;
        }
    }
}