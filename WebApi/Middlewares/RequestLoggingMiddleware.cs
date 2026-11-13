namespace WebApi.Middlewares;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;
    public async Task InvokeAsync(HttpContext httpContext)
    {
        _logger.LogInformation($"Request: {httpContext.Request.Path} {DateTime.Now}");
        await _next(httpContext);
        _logger.LogInformation($"Request: {httpContext.Response.StatusCode} {DateTime.Now}");
    }
}