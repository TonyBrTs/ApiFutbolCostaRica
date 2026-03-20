using Microsoft.EntityFrameworkCore;
using ApiFutbolCostaRica.Infrastructure.Persistence;
using ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la Base de Datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrar MediatR (Busca los comandos en la capa Application)
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateTeamCommand).Assembly);
});

// 3. ¡IMPORTANTE! Registrar los Controladores
builder.Services.AddControllers();

// 4. Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Activar Swagger (Lo dejamos fuera del IF por ahora para asegurar que lo veas)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fútbol CR v1");
    c.RoutePrefix = "swagger"; // Esto hace que cargue en la raíz /swagger
});

app.UseHttpsRedirection();
app.UseAuthorization();

// 6. Mapear los controladores para que reconozca el TeamsController
app.MapControllers();

app.Run();