using ApiFutbolCostaRica.Application.Features.Players.Commands.CreatePlayer;
using ApiFutbolCostaRica.Application.Features.Players.Commands.UpdatePlayer;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetAllTeams;
using ApiFutbolCostaRica.Application.Features.Players.Queries.GetAllPlayers;
using ApiFutbolCostaRica.Application.Features.Players.Queries.GetPlayerById;
using ApiFutbolCostaRica.Application.Features.Players.Queries.GetPlayerByName;
using ApiFutbolCostaRica.Application.Features.Players.Commands.DeletePlayer;
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
            Message = "Player created in the Costa Rica database!",
            PlayerId = playerId
        });
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePlayer([FromBody] UpdatePlayerCommand command)
    {
        var playerId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "Player updated in the Costa Rica database!",
            PlayerId = playerId
        });
    }

    // [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = await _mediator.Send(new GetAllPlayersQuery());
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayerById(int id)
    {
        var player = await _mediator.Send(new GetPlayerByIdQuery { Id = id });
        if (player == null)
        {
            return NotFound();
        }
        return Ok(player);
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetPlayerByName(string name)
    {
        var players = await _mediator.Send(new GetPlayerByNameQuery { Name = name });
        return Ok(players);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var playerId = await _mediator.Send(new DeletePlayerCommand { Id = id });
        return Ok(new
        {
            Message = "Player deleted from the Costa Rica database!",
            PlayerId = playerId
        });
    }
}