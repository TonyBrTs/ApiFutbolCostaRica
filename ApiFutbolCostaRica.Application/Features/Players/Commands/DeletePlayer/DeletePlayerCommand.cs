using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Players.Commands.DeletePlayer;

public class DeletePlayerCommand : IRequest<int>
{
    public int Id { get; set; }
}