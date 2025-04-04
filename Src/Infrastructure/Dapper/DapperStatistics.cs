using Dapper;
using Domain.Interfaces.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.EntityFrameworkDiver;
public class DapperStatistics: IDapperStatistics
{
    private readonly string _connectionString;
   

    public DapperStatistics(string connectionString)
    {
        _connectionString = connectionString;
    }

    public  object GetYellowCards()
    {
        using (IDbConnection _dbConnection = new SqlConnection(_connectionString))
        {
            _dbConnection.Open();
            var sql = "select count(*) as cards from dbo.Players where YellowCard=1";
            var response = _dbConnection.Query<object>(sql);
            _dbConnection.Close();
            return response;
        }
    }

    public object GetRedCards()
    {
        using (IDbConnection _dbConnection = new SqlConnection(_connectionString))
        {
            var sql = "select count(*) as cards from dbo.Players where RedCard=1";
            _dbConnection.Open();
            var response = _dbConnection.Query<object>(sql);
            _dbConnection.Close();
            return response;
        }
    }

    public  object GetMinutesPlayed()
    {
        using (IDbConnection _dbConnection = new SqlConnection(_connectionString))
        {
            var sql = "select count(*) as cards from dbo.Players where MinutesPlayed=1";
            _dbConnection.Open();
            var response = _dbConnection.Query<object>(sql);
            _dbConnection.Close();
            return response;
        }
    }
}
