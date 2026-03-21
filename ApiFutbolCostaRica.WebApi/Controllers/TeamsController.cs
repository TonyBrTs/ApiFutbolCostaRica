using ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;
using ApiFutbolCostaRica.Application.Features.Teams.Commands.UpdateTeam;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamById;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetAllTeams;
using MediatR;
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

    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamCommand command)
    {
        // Enviamos el comando a través de MediatR
        var teamId = await _mediator.Send(command);

        // Retornamos una respuesta exitosa con el ID generado en la BD
        return Ok(new
        {
            Message = "¡Equipo creado en la base de datos de Costa Rica!",
            TeamId = teamId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(int id, [FromBody] UpdateTeamCommand command)
    {
        command.Id = id;
        var teamId = await _mediator.Send(command);
        return Ok(new
        {
            Message = "¡Equipo actualizado en la base de datos de Costa Rica!",
            TeamId = teamId
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var team = await _mediator.Send(new GetTeamByIdQuery { Id = id });

        if (team == null)
            return NotFound(new { Message = "Equipo no encontrado" });

        return Ok(team);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }
}