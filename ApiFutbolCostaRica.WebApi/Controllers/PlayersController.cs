using ApiFutbolCostaRica.Application.Features.Players.Commands.CreatePlayer;
using ApiFutbolCostaRica.Application.Features.Players.Commands.UpdatePlayer;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetAllTeams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiFutbolCostaRica.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IMediator _mediator;
    public PlayersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerCommand command)
    {
        var playerId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "¡Jugador creado en la base de datos de Costa Rica!",
            PlayerId = playerId
        });
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePlayer([FromBody] UpdatePlayerCommand command)
    {
        var playerId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "¡Jugador actualizado en la base de datos de Costa Rica!",
            PlayerId = playerId
        });
    }

    // [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }
}