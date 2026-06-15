using Gateway.Extensions;
using LogLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLog();
builder.Services.AddLogService();

builder.Configuration.ConfigureGate();
var gatewayConfig = builder.Configuration.ConfigureSection();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGateConfiguration(gatewayConfig);

var app = builder.Build();

app.UseLog();
app.UseGateMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
