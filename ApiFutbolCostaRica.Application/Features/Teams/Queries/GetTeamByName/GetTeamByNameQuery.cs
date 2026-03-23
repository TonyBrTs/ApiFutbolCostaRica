using MediatR;
using ApiFutbolCostaRica.Domain.Entities;
using System.Collections.Generic;

namespace ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamByName;

public class GetTeamByNameQuery : IRequest<IEnumerable<Team>>
{
    public string Name { get; set; } = string.Empty;
}
