using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Sync.Commands.SyncMatches;

public class SyncMatchesCommand : IRequest<bool>
{
    public int LeagueId { get; set; }
    public int Season { get; set; }
}
