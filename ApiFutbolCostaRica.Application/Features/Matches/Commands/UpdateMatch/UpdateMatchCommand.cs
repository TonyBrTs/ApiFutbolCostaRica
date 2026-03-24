using MediatR;
using System;

namespace ApiFutbolCostaRica.Application.Features.Matches.Commands.UpdateMatch;

public class UpdateMatchCommand : IRequest<int>
{
    public int Id { get; set; }
    public DateTime MatchDate { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Referee { get; set; } = string.Empty;
    public string Venue { get; set; } = string.Empty;
}
