using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.UpdateTeam;

public class UpdateTeamCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? FoundationYear { get; set; }
    public string? Stadium { get; set; }
}

