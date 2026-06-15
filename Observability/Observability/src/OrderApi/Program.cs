using LogLibrary.Extensions;
using OrderApi.Clients;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLog();
builder.Services.AddLogService();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICatalogClient, CatalogClient>(client =>
{
    client.BaseAddress = new Uri("http://catalogapi:4003");
    client.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

app.UseLog();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
