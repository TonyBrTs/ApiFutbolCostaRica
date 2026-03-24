using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace ApiFutbolCostaRica.Application.Features.Players.Queries.GetPlayerByName;

public class GetPlayerByNameQueryHandler : IRequestHandler<GetPlayerByNameQuery, IEnumerable<Player>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerByNameQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<IEnumerable<Player>> Handle(GetPlayerByNameQuery request, CancellationToken cancellationToken)
    {
        return await _playerRepository.GetPlayersByName(request.Name);
    }
}
