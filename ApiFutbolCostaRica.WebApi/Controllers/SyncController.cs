using ApiFutbolCostaRica.Application.Features.Sync.Commands.SyncLeagueData;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SyncController : ControllerBase
{
    private readonly IMediator _mediator;

    public SyncController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Synchronizes league and team data from external API.
    /// </summary>
    [HttpPost("league/{leagueId}")]
    public async Task<IActionResult> SyncLeague(int leagueId, [FromQuery] int season = 2023)
    {
        var command = new SyncLeagueDataCommand { LeagueId = leagueId, Season = season };
        var result = await _mediator.Send(command);

        if (result)
            return Ok(new { Message = $"League {leagueId} synchronization completed successfully." });

        return StatusCode(500, new { Message = "An error occurred during synchronization." });
    }

    /// <summary>
    /// Synchronizes match data for a given league from external API.
    /// </summary>
    [HttpPost("matches/{leagueId}")]
    public async Task<IActionResult> SyncMatches(int leagueId, [FromQuery] int season = 2023)
    {
        var command = new ApiFutbolCostaRica.Application.Features.Sync.Commands.SyncMatches.SyncMatchesCommand { LeagueId = leagueId, Season = season };
        var result = await _mediator.Send(command);

        if (result)
            return Ok(new { Message = $"Match synchronization for league {leagueId} completed successfully." });

        return StatusCode(500, new { Message = "An error occurred during match synchronization." });
    }
}
