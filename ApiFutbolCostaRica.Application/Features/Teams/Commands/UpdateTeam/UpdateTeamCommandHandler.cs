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
        // 1. Buscamos el equipo real en la base de datos
        var existingTeam = await _teamRepository.GetTeamById(request.Id);

        if (existingTeam == null) return 0;

        // 2. Solo actualizamos lo que NO sea nulo en la petición
        if (request.Name != null) 
            existingTeam.Name = request.Name;
            
        if (request.FoundationYear.HasValue) 
            existingTeam.FoundationYear = request.FoundationYear.Value;
            
        if (request.Stadium != null) 
            existingTeam.Stadium = request.Stadium;

        // 3. Guardamos el objeto ya actualizado
        return await _teamRepository.UpdateTeam(existingTeam);
    }
}