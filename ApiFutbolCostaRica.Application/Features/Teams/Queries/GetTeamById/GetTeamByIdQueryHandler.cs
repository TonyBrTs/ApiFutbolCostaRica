using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;

namespace ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamById;

public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Team?>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamByIdQueryHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Team?> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        // Solo llama al repositorio pasándole el ID
        return await _teamRepository.ObtenerEquipoPorId(request.Id);
    }
}