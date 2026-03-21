using FluentValidation;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.DeleteTeam;

public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
{
    public DeleteTeamCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("El ID del equipo debe ser mayor a 0.");
    }
}
