using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

namespace LogLibrary.Extensions
{
    public static class LogConfigurationExtension
    {
        public static void AddLog(this IHostBuilder host)
        {
            host.UseSerilog((ctx, cfg) =>
                {
                    cfg.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
                        .Enrich.WithProperty(
                            "Application", 
                            ctx.HostingEnvironment.ApplicationName + "_" + ctx.HostingEnvironment.EnvironmentName)
                        .WriteTo.GrafanaLoki(ctx.Configuration["Loki"], outputTemplate: "{Message}");
                });
        }
    }
}