using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Players.Queries.GetPlayerById;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
{
    private readonly IPlayerRepository _playerRepository;
    public GetPlayerByIdQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _playerRepository.GetPlayerById(request.Id);
    }
}