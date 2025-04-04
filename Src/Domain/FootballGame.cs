using Domain.Entities;
using Domain.Interfaces;

namespace Domain;
public class FootballGame: IFootballGame
{
    private readonly List<Game> _games;
    public FootballGame() 
    {
        _games = new List<Game>
        {
            new Game { GameId = 1, TeamA = "ARgentina", TeamB = "Brasil", StartTime = DateTime.UtcNow.AddMinutes(5), IsLineupCorrect = false },
            new Game { GameId = 2, TeamA = "Portugal", TeamB = "Francia", StartTime = DateTime.UtcNow.AddMinutes(10), IsLineupCorrect = true },
        };
    }
    public Task<IEnumerable<Game>> GetGamesStart()
    {
        var games = _games.Where(g => g.StartTime <= DateTime.UtcNow.AddMinutes(5) && g.StartTime > DateTime.UtcNow);
        return Task.FromResult(games.AsEnumerable());
    }
}
