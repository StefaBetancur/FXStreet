namespace Domain.Entities;
public class Game
{
    public int GameId { get; set; }
    public string TeamA { get; set; }
    public string TeamB { get; set; }
    public DateTime StartTime { get; set; }
    public bool IsLineupCorrect { get; set; }
}
