using Serilog;
using Taking.Robson.Application.Interfaces;
using Taking.Robson.Application.Services;
using Taking.Robson.Domain.Entities;
using Taking.Robson.Domain.Interfaces;
using Taking.Robson.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//
//app.MapControllers();

app.UseRouting();
app.UseSerilogRequestLogging();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.Run();

try
{
    Log.Information("Iniciando a aplicação 123Vendas.API...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplicação falhou ao iniciar.");
}
finally
{
    Log.CloseAndFlush();
}