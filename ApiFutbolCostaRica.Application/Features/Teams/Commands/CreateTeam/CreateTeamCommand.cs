using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int FoundationYear { get; set; }
    public string Stadium { get; set; } = string.Empty;
}
