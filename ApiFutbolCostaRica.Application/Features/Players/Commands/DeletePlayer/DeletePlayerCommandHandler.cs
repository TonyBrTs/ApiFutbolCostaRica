using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Players.Commands.DeletePlayer;

public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, int>
{
    private readonly IPlayerRepository _playerRepository;

    public DeletePlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<int> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        return await _playerRepository.EliminarJugador(request.Id);
    }
}