using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Features.Matches.Commands.CreateMatch;

public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int>
{
    private readonly IMatchRepository _matchRepository;

    public CreateMatchCommandHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
    {
        var match = new Match
        {
            MatchDate = request.MatchDate,
            HomeTeamId = request.HomeTeamId,
            AwayTeamId = request.AwayTeamId,
            HomeTeamGoals = request.HomeTeamGoals,
            AwayTeamGoals = request.AwayTeamGoals,
            Status = request.Status,
            Referee = request.Referee,
            Venue = request.Venue
        };

        return await _matchRepository.RegisterNewMatch(match);
    }
}
