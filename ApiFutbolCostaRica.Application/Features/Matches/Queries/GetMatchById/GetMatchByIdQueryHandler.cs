using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Features.Matches.Queries.GetMatchById;

public class GetMatchByIdQueryHandler : IRequestHandler<GetMatchByIdQuery, Match?>
{
    private readonly IMatchRepository _matchRepository;

    public GetMatchByIdQueryHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<Match?> Handle(GetMatchByIdQuery request, CancellationToken cancellationToken)
    {
        return await _matchRepository.ObtenerPartidoPorId(request.Id);
    }
}
