using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace ApiFutbolCostaRica.Application.Features.Matches.Commands.UpdateMatch;

public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, int>
{
    private readonly IMatchRepository _matchRepository;

    public UpdateMatchCommandHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<int> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
    {
        var match = await _matchRepository.ObtenerPartidoPorId(request.Id);
        if (match == null)
            throw new Exception($"El partido con Id {request.Id} no existe.");

        match.MatchDate = request.MatchDate;
        match.HomeTeamId = request.HomeTeamId;
        match.AwayTeamId = request.AwayTeamId;
        match.HomeTeamGoals = request.HomeTeamGoals;
        match.AwayTeamGoals = request.AwayTeamGoals;
        match.Status = request.Status;
        match.Referee = request.Referee;
        match.Venue = request.Venue;

        return await _matchRepository.ActualizarPartido(match);
    }
}
