using Gateway.Clients;
using Gateway.Configuration;
using Gateway.Extensions;
using System.Net;

namespace Gateway.Middlewares
{
    public class GateMiddleware
    {
        private readonly GatewayConfig _gatewayConfig;

        private readonly IOrderClient _orderClient;

        private readonly RequestDelegate _next;
            
        public GateMiddleware(
            RequestDelegate next,
            GatewayConfig gatewayConfig,
            IOrderClient orderClient)
        {
            _next = next;
            _gatewayConfig = gatewayConfig;
            _orderClient = orderClient;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers
                .TryGetValue("X-Gate-Api", out var gateApi))
            {
                ReturnBadRequestResponse(context);
                return;
            }

            var api = _gatewayConfig.Apis.FirstOrDefault(x => x.Name == gateApi);

            if (api is null)
            {
                ReturnBadRequestResponse(context);
                return;
            }

            var routeConfiguration = api.Routes
                .FirstOrDefault(r => r.Path == context.Request.Path && r.Method == context.Request.Method);

            if (routeConfiguration is null)
            {
                ReturnBadRequestResponse(context);
                return;
            }

            var response = await _orderClient.SendAsync(context);

            await context.CopyProxyHttpResponse(response);
        }

        private void ReturnBadRequestResponse(HttpContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
        }
    }
}