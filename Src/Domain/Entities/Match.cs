namespace Domain.Entities;
public class Match
{
    public int Id { get; set; }

    public ICollection<Manager> HouseManager { get; set; }
    public ICollection<Manager> AwayManager { get; set; }

    public ICollection<Player> HousePlayers { get; set; }
    public ICollection<Player> AwayPlayers { get; set; }

    public Referee Referee { get; set; }
}
