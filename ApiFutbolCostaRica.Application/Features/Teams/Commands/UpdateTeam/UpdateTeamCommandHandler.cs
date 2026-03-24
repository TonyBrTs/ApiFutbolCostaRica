using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, int>
{
    private readonly ITeamRepository _teamRepository;

    public UpdateTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<int> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var existingTeam = await _teamRepository.GetTeamById(request.Id);

        if (existingTeam == null) return 0;

        if (request.Name != null) 
            existingTeam.Name = request.Name;
            
        if (request.FoundationYear.HasValue) 
            existingTeam.FoundationYear = request.FoundationYear.Value;
            
        if (request.Stadium != null) 
            existingTeam.Stadium = request.Stadium;

        return await _teamRepository.UpdateTeam(existingTeam);
    }
}