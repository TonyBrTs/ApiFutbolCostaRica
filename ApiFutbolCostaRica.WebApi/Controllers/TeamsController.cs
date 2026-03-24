using ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;
using ApiFutbolCostaRica.Application.Features.Teams.Commands.UpdateTeam;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamById;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamByName;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetAllTeams;
using ApiFutbolCostaRica.Application.Features.Teams.Commands.DeleteTeam;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiFutbolCostaRica.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly IMediator _mediator;

    // Inyectamos MediatR para comunicarnos con la capa de Application
    public TeamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // [Authorize(Roles = "Admin")] // Comentado por ahora para permitir pruebas libres
    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand command)
    {
        // Enviamos el comando a través de MediatR
        var teamId = await _mediator.Send(command);

        // Return a successful response with the generated ID in the DB
        return Ok(new
        {
            Message = "Team created in the Costa Rica database!",
            TeamId = teamId
        });
    }

    // [Authorize(Roles = "Admin")] // Comentado por ahora para permitir pruebas libres
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(int id, [FromBody] UpdateTeamCommand command)
    {
        command.Id = id;
        var teamId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "Team updated in the Costa Rica database!",
            TeamId = teamId
        });
    }

    // [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var team = await _mediator.Send(new GetTeamByIdQuery { Id = id });

        if (team == null)
            return NotFound(new { Message = "Team not found" });

        return Ok(team);
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetTeamByName(string name)
    {
        var teams = await _mediator.Send(new GetTeamByNameQuery { Name = name });
        return Ok(teams);
    }

    // [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }

    // [Authorize(Roles = "Admin")] // Commented for now to allow free testing
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var result = await _mediator.Send(new DeleteTeamCommand { Id = id });

        if (!result)
            return NotFound(new { Message = "Could not delete: Team not found" });

        return Ok(new { Message = "Team deleted from the Costa Rica database!" });
    }
}