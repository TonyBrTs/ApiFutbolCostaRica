using ApiFutbolCostaRica.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace ApiFutbolCostaRica.Application.Features.Matches.Queries.GetAllMatches;

public class GetAllMatchesQuery : IRequest<IEnumerable<Match>>
{
}
