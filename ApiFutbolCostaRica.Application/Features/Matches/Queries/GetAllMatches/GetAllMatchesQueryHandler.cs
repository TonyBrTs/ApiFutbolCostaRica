using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Features.Matches.Queries.GetAllMatches;

public class GetAllMatchesQueryHandler : IRequestHandler<GetAllMatchesQuery, IEnumerable<Match>>
{
    private readonly IMatchRepository _matchRepository;

    public GetAllMatchesQueryHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<IEnumerable<Match>> Handle(GetAllMatchesQuery request, CancellationToken cancellationToken)
    {
        return await _matchRepository.GetAllMatches();
    }
}
