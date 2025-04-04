using Domain.Entities;

namespace Domain.Interfaces;
public interface IFootballGame
{
    Task<IEnumerable<Game>> GetGamesStart();
}
