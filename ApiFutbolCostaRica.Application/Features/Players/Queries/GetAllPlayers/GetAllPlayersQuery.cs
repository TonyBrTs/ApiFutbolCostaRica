using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ApiFutbolCostaRica.Domain.Entities;
namespace ApiFutbolCostaRica.Application.Features.Players.Queries.GetAllPlayers;

public class GetAllPlayersQuery: IRequest <IEnumerable<Player>>
{
}
