using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamByName;

public class GetTeamByNameQueryHandler : IRequestHandler<GetTeamByNameQuery, IEnumerable<Team>>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamByNameQueryHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Team>> Handle(GetTeamByNameQuery request, CancellationToken cancellationToken)
    {
        return await _teamRepository.GetTeamsByName(request.Name);
    }
}
