using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Features.Matches.Commands.DeleteMatch;

public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand, int>
{
    private readonly IMatchRepository _matchRepository;

    public DeleteMatchCommandHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<int> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
    {
        return await _matchRepository.EliminarPartido(request.Id);
    }
}
