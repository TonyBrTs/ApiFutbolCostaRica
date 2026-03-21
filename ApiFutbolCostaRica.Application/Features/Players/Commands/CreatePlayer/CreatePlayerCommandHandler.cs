using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Players.Commands.CreatePlayer;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
{
    private readonly IPlayerRepository _playerRepository;
    public CreatePlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            Name = request.Name,
            Position = request.Position,
            Nationality = request.Nationality,
            Age = request.Age,
            TeamId = request.TeamId
        };
        return await _playerRepository.RegistrarNuevoJugador(player);
    }
}