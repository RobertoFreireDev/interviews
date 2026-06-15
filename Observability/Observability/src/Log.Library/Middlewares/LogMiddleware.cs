using LogLibrary.Services;
using LogLibrary.Constants;
using LogLibrary.Structs;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;

namespace LogLibrary.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogRequestService logRequestService)
        {
            var utcNow = DateTime.UtcNow;
            var traceKey = Guid.NewGuid().ToString() + "_" + utcNow;

            logRequestService.AdditionalData = new Dictionary<string, object>();

            if (!context.Request.Headers.TryGetValue(LogConstant.TraceIdHeader, out var traceKeyHeaderValue))
            {
                context.Request.Headers.Add(LogConstant.TraceIdHeader, traceKey);
            } 
            else
            {
                traceKey = traceKeyHeaderValue;
            }

            var log = new LogRequestObject(utcNow, traceKey);

            var watch = Stopwatch.StartNew();

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                log.ExceptionMessage = ex.Message;
                log.ExceptionStackTrace = ex.StackTrace;
            }
            finally
            {
                watch.Stop();

                log.ElapsedMilliseconds = watch.ElapsedMilliseconds;
                log.AdditionalData = logRequestService.AdditionalData;

                Serilog.Log.Information(JsonSerializer.Serialize(log));
            }
        }
    }
}
