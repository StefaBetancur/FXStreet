using Cronos;
using Domain.Interfaces;
namespace FootballJob;
public class CronJobService : IHostedService, IDisposable
{
    private readonly string _cronExpression = "*/5 * * * *";
    private Timer? _timer;
    private DateTime _nextRun;
    private readonly IFootballGame _FootballGame;

    public CronJobService(IFootballGame footballGame) 
    { 
        _FootballGame = footballGame;
    }

    public Task StartAsync( CancellationToken cancellationToken)
    {
        _nextRun = CronExpression.Parse(_cronExpression).GetNextOccurrence(DateTime.UtcNow) ?? DateTime.UtcNow;
        _timer = new Timer(ExecuteJob, null, _nextRun - DateTime.UtcNow, Timeout.InfiniteTimeSpan);
        return Task.CompletedTask;
    }

    private async void ExecuteJob(object? state)
    {

        var games = await  _FootballGame.GetGamesStart(); 

        foreach (var game in games)
        {
            if (!game.IsLineupCorrect)
            {
                Console.WriteLine($"ALERTA: Alineación incorrecta en el juego {game.TeamA} vs {game.TeamB} que comienza en 5 minutos.");
                
            }
        } 

        _nextRun = CronExpression.Parse(_cronExpression).GetNextOccurrence(DateTime.UtcNow) ?? DateTime.UtcNow;
        _timer?.Change(_nextRun - DateTime.UtcNow, Timeout.InfiniteTimeSpan);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
