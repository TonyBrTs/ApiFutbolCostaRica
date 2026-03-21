using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Players.Commands.CreatePlayer;

public class CreatePlayerCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public int? TeamId { get; set; }
}