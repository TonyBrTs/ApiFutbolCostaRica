using global::ApiFutbolCostaRica.Domain.Interfaces;
using global::ApiFutbolCostaRica.Domain.Entities;
using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Players.Commands.UpdatePlayer;

public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Unit>
{
    private readonly IPlayerRepository _playerRepository;

    public UpdatePlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.ObtenerJugadorPorId(request.Id);
        if (player == null)
        {
            throw new Exception("Player not found");
        }

        player.Name = request.Name;
        player.Position = request.Position;
        player.Age = request.Age;
        player.Nationality = request.Nationality;
        player.TeamId = request.TeamId;

        await _playerRepository.ActualizarJugador(player);
        return Unit.Value;
    }
}