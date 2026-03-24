using ApiFutbolCostaRica.Application.Features.Matches.Commands.CreateMatch;
using ApiFutbolCostaRica.Application.Features.Matches.Commands.UpdateMatch;
using ApiFutbolCostaRica.Application.Features.Matches.Commands.DeleteMatch;
using ApiFutbolCostaRica.Application.Features.Matches.Queries.GetAllMatches;
using ApiFutbolCostaRica.Application.Features.Matches.Queries.GetMatchById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MatchesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMatch([FromBody] CreateMatchCommand command)
    {
        var matchId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "¡Partido creado exitosamente!",
            MatchId = matchId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMatch(int id, [FromBody] UpdateMatchCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest(new { Message = "El ID de la ruta no coincide con el ID del cuerpo de la petición." });
        }

        var matchId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "¡Partido actualizado exitosamente!",
            MatchId = matchId
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMatches()
    {
        var matches = await _mediator.Send(new GetAllMatchesQuery());
        return Ok(matches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatchById(int id)
    {
        var match = await _mediator.Send(new GetMatchByIdQuery { Id = id });
        if (match == null)
        {
            return NotFound(new { Message = $"No se encontró el partido con ID {id}" });
        }
        return Ok(match);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatch(int id)
    {
        var result = await _mediator.Send(new DeleteMatchCommand { Id = id });
        
        if (result == 0)
        {
            return NotFound(new { Message = $"No se encontró el partido con ID {id}" });
        }

        return Ok(new
        {
            Message = "¡Partido eliminado exitosamente!",
            RowsAffected = result
        });
    }
}
