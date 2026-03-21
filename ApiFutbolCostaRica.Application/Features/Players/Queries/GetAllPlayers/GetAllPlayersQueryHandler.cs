using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;

namespace ApiFutbolCostaRica.Application.Features.Players.Queries.GetAllPlayers;

public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player>>
{
    private readonly IPlayerRepository _playerRepository;
    public GetAllPlayersQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<IEnumerable<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        return await _playerRepository.ObtenerTodosLosJugadores();
    }
}





