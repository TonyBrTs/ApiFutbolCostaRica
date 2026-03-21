using MediatR;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Application.Features.Teams.Queries.GetAllTeams;

public class GetAllTeamsQuery : IRequest<IEnumerable<Team>>
{
}