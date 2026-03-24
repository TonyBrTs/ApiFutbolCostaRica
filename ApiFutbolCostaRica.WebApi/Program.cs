using Microsoft.EntityFrameworkCore;
using ApiFutbolCostaRica.Infrastructure.Persistence;
using ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;
using ApiFutbolCostaRica.Domain.Interfaces;
using ApiFutbolCostaRica.Infrastructure.Repositories;
using FluentValidation;
using ApiFutbolCostaRica.Application.Common.Behaviors;
using MediatR;
using ApiFutbolCostaRica.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la Base de Datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrar MediatR y FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(CreateTeamCommand).Assembly);

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateTeamCommand).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

// Registrar Repositorios
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();

// 3. Configurar API-Football Externa
builder.Services.AddHttpClient<ApiFutbolCostaRica.Application.Interfaces.IFootballApiService, ApiFutbolCostaRica.Infrastructure.ExternalServices.FootballApi.FootballApiService>(client =>
{
    var footballApiConfig = builder.Configuration.GetSection("FootballApi");
    client.BaseAddress = new Uri(footballApiConfig["BaseUrl"] ?? "https://v3.football.api-sports.io/");
    client.DefaultRequestHeaders.Add("x-apisports-key", footballApiConfig["ApiKey"]);
});

// 4. ¡IMPORTANTE! Registrar los Controladores
builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// 5. Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar el Middleware de excepciones globales
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    // 6. Activar Swagger únicamente en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fútbol CR v1");
        c.RoutePrefix = "swagger"; // Esto hace que cargue en la raíz /swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// 7. Mapear los controladores para que reconozca el TeamsController
app.MapControllers();

app.Run();