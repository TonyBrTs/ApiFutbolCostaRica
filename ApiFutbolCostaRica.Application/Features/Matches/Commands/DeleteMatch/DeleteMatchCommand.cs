using MediatR;

namespace ApiFutbolCostaRica.Application.Features.Matches.Commands.DeleteMatch;

public class DeleteMatchCommand : IRequest<int>
{
    public int Id { get; set; }
}
