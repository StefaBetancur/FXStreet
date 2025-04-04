namespace Domain.Interfaces.Infrastructure;
public interface IDapperStatistics
{
    object GetYellowCards();
    object GetRedCards();
    object GetMinutesPlayed();
}
