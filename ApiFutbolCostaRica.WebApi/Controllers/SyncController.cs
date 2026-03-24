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

    [HttpPost("league/{leagueId}")]
    public async Task<IActionResult> SyncLeague(int leagueId, [FromQuery] int season = 2023)
    {
        var command = new SyncLeagueDataCommand { LeagueId = leagueId, Season = season };
        var result = await _mediator.Send(command);

        if (result)
            return Ok(new { Message = $"Sincronización de la liga {leagueId} completada con éxito." });

        return StatusCode(500, new { Message = "Ocurrió un error durante la sincronización." });
    }
}
