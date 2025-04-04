using Domain.Interfaces;
using Domain.Interfaces.Infrastructure;

namespace Domain;
public class FootballStatisticsService: IFootballStatisticsService
{
    private readonly IDapperStatistics _dapperStatistics;
    public FootballStatisticsService(IDapperStatistics dapperStatistics) 
    {
        _dapperStatistics = dapperStatistics;
    }

    public  object GetYellowCards() 
    { 
        return  _dapperStatistics.GetYellowCards();
    }
    public  object GetRedCards() 
    {
        return  _dapperStatistics.GetRedCards();
    }
    public  object GetMinutesPlayed() 
    {
        return  _dapperStatistics.GetMinutesPlayed();
    }

}
