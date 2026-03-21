using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

// 1. EL COMANDO (La "nota" con los datos que envía el usuario)
// IRequest<int> significa que al terminar de ejecutarse, devolverá un número entero (el ID del nuevo equipo)
public class CreateTeamCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int FoundationYear { get; set; }
    public string Stadium { get; set; } = string.Empty;
}
