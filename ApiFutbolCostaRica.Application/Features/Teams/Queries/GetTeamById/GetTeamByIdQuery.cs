using MediatR;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamById;

public class GetTeamByIdQuery : IRequest<Team?>
{
    public int Id { get; set; }
}