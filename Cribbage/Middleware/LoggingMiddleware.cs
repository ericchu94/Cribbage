using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cribbage.Middleware
{
    class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await next(context);
            watch.Stop();
            var request = context.Request;
            var requestLine = String.Format("{0} {1} {2}", request.Method, request.Path, request.Protocol);
            logger.LogInformation("{0} {1} {2}ms", requestLine, context.Response.StatusCode, watch.ElapsedMilliseconds);
        }
    }
}
