using ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;
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
}