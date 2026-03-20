using MediatR;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

// 1. EL COMANDO (La "nota" con los datos que envía el usuario)
// IRequest<int> significa que al terminar de ejecutarse, devolverá un número entero (el ID del nuevo equipo)
public class CreateTeamCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int FoundationYear { get; set; }
    public string Stadium { get; set; } = string.Empty;
}

// 2. EL MANEJADOR (El "cocinero" que ejecuta la lógica)
public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
{
    // Constructor: Aquí inyectaremos la base de datos en el Paso 3
    public CreateTeamCommandHandler()
    {
    }

    // Este es el método que MediatR ejecuta automáticamente
    public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        // 1. Mapear los datos del comando hacia nuestra entidad pura del Dominio
        var newTeam = new Team
        {
            Name = request.Name,
            FoundationYear = request.FoundationYear,
            Stadium = request.Stadium
        };

        // 2. Aquí irá el código para guardar "newTeam" en la base de datos usando Entity Framework.
        // _dbContext.Teams.Add(newTeam);
        // await _dbContext.SaveChangesAsync(cancellationToken);

        // 3. Por ahora, simulamos que la base de datos le asignó el ID 1 y lo devolvemos
        return await Task.FromResult(1);
    }
}