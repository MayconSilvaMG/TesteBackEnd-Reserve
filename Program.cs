using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FlightSearchAPI.Services;
using FlightSearchAPI.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddHttpClient<GolService>();
builder.Services.AddHttpClient<LatamService>();
builder.Services.AddScoped<IAirlineService, GolService>();
builder.Services.AddScoped<IAirlineService, LatamService>();

// Adicionar serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "FlightSearchAPI",
        Version = "v1"
    });
});

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightSearchAPI V1");
        c.RoutePrefix = string.Empty; // Define o Swagger como a página inicial
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
