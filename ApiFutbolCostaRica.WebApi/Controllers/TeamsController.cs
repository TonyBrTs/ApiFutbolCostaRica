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

    /// <summary>
    /// Initializes a new instance of the TeamsController.
    /// </summary>
    public TeamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new team.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand command)
    {
        var teamId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "Team created in the Costa Rica database!",
            TeamId = teamId
        });
    }

    /// <summary>
    /// Updates an existing team.
    /// </summary>
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

    /// <summary>
    /// Retrieves a team by its ID.
    /// </summary>
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

    /// <summary>
    /// Retrieves all teams.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }

    /// <summary>
    /// Deletes a team.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var result = await _mediator.Send(new DeleteTeamCommand { Id = id });

        if (!result)
            return NotFound(new { Message = "Could not delete: Team not found" });

        return Ok(new { Message = "Team deleted from the Costa Rica database!" });
    }
}