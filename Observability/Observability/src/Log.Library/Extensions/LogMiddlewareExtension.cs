using LogLibrary.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace LogLibrary.Extensions
{
    public static class LogMiddlewareExtension
    {
        public static void UseLog(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LogMiddleware>();
        }
    }
}
