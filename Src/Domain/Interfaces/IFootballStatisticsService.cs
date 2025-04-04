namespace Domain.Interfaces;
public interface IFootballStatisticsService
{
    object GetYellowCards();
    object GetRedCards();
    object GetMinutesPlayed();

}
