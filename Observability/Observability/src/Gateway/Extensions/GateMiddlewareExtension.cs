using Gateway.Middlewares;

namespace Gateway.Extensions
{
    public static class GateMiddlewareExtension
    {
        public static void UseGateMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GateMiddleware>();
        }
    }
}
