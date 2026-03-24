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
        return await _teamRepository.GetTeamById(request.Id);
    }
}