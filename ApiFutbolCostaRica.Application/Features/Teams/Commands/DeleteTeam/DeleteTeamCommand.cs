using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.DeleteTeam;

public class DeleteTeamCommand : IRequest<bool>
{
    public int Id { get; set; }
}
