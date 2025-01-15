using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Monolith.Module1;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Append("X-Module-1-Header", "value");

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}