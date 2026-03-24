using ApiFutbolCostaRica.Domain.Entities;
using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Matches.Queries.GetMatchById;

public class GetMatchByIdQuery : IRequest<Match?>
{
    public int Id { get; set; }
}
