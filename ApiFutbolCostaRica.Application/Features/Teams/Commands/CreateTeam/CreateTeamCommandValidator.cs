using FluentValidation;

namespace ApiFutbolCostaRica.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
            .MaximumLength(100).WithMessage("{PropertyName} no debe exceder 100 caracteres.");

        RuleFor(p => p.FoundationYear)
            .InclusiveBetween(1800, 2100).WithMessage("{PropertyName} debe ser un año entre 1800 y 2100.");

        RuleFor(p => p.Stadium)
            .MaximumLength(150).WithMessage("{PropertyName} no debe exceder 150 caracteres.");
    }
}
