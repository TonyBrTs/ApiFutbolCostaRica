using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
{
    private readonly ITeamRepository _teamRepository;

    public CreateTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var newTeam = new Team
        {
            Name = request.Name,
            FoundationYear = request.FoundationYear,
            Stadium = request.Stadium
        };

        return await _teamRepository.RegisterNewTeam(newTeam);
    }
}
