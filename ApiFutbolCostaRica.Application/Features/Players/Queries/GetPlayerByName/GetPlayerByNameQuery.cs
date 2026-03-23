using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using System.Collections.Generic;

namespace ApiFutbolCostaRica.Application.Features.Players.Queries.GetPlayerByName;

public class GetPlayerByNameQuery : IRequest<IEnumerable<Player>>
{
    public string Name { get; set; } = string.Empty;
}
