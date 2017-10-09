using Microsoft.AspNetCore.Builder;

namespace Cribbage.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogging(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
