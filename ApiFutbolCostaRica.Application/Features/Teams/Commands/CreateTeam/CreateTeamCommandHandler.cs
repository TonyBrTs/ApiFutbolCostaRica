using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

// 2. EL MANEJADOR (El "cocinero" que ejecuta la lógica)
public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
{
    private readonly ITeamRepository _teamRepository;

    // Constructor: Inyectamos el repositorio para interactuar con los datos (vía Dominio)
    public CreateTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
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

        // 2. Guardar "newTeam" en la base de datos a través del repositorio
        return await _teamRepository.RegisterNewTeam(newTeam);
    }
}
