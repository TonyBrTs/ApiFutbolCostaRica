using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Sync.Commands.SyncLeagueData;

public class SyncLeagueDataCommand : IRequest<bool>
{
    public int LeagueId { get; set; } = 167; // Costa Rica por defecto
    public int Season { get; set; } = 2023; // Temporada por defecto
}
