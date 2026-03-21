using ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;
using ApiFutbolCostaRica.Application.Features.Teams.Commands.UpdateTeam;
using ApiFutbolCostaRica.Application.Features.Teams.Queries.GetTeamById;
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

        // Retornamos una respuesta exitosa con el ID generado en la BD
        return Ok(new
        {
            Message = "¡Equipo creado en la base de datos de Costa Rica!",
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
            Message = "¡Equipo actualizado en la base de datos de Costa Rica!",
            TeamId = teamId
        });
    }

    // [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var team = await _mediator.Send(new GetTeamByIdQuery { Id = id });

        if (team == null)
            return NotFound(new { Message = "Equipo no encontrado" });

        return Ok(team);
    }

    // [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(teams);
    }

    // [Authorize(Roles = "Admin")] // Comentado por ahora para permitir pruebas libres
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarEquipo(int id)
    {
        var result = await _mediator.Send(new DeleteTeamCommand { Id = id });

        if (!result)
            return NotFound(new { Message = "No se pudo eliminar: Equipo no encontrado" });

        return Ok(new { Message = "¡Equipo eliminado de la base de datos de Costa Rica!" });
    }
}