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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssembly(typeof(CreateTeamCommand).Assembly);

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateTeamCommand).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();

builder.Services.AddHttpClient<ApiFutbolCostaRica.Application.Interfaces.IFootballApiService, ApiFutbolCostaRica.Infrastructure.ExternalServices.FootballApi.FootballApiService>(client =>
{
    var footballApiConfig = builder.Configuration.GetSection("FootballApi");
    client.BaseAddress = new Uri(footballApiConfig["BaseUrl"] ?? "https://v3.football.api-sports.io/");
    client.DefaultRequestHeaders.Add("x-apisports-key", footballApiConfig["ApiKey"]);
});

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fútbol CR v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();