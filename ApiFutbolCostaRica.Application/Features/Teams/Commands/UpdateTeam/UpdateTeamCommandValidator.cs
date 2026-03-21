using FluentValidation;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0).WithMessage("El ID del equipo debe ser mayor a 0.");

        RuleFor(p => p.Name)
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 100 caracteres.")
            .When(p => p.Name != null);

        RuleFor(p => p.FoundationYear)
            .InclusiveBetween(1800, 2100).WithMessage("{PropertyName} debe ser un año entre 1800 y 2100.")
            .When(p => p.FoundationYear.HasValue);

        RuleFor(p => p.Stadium)
            .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.")
            .When(p => p.Stadium != null);
    }
}
