using MediatR;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Application.Features.Players.Queries.GetPlayerById;

public class GetPlayerByIdQuery : IRequest<Player?>
{
    public int Id { get; set; }
}