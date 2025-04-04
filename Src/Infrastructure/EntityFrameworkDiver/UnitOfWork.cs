using Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.EntityFrameworkDiver;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FootballContext _context;
    private IDbContextTransaction _dbContextTransaction { get; set; }

    public UnitOfWork(FootballContext context)
    {
        _context = context;
    }

    public void CreateTransaction()
    {
        _dbContextTransaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        if (_dbContextTransaction!= null) { _dbContextTransaction.Commit(); }
    }
    public void Rollback()
    {
        if (_dbContextTransaction != null) { _dbContextTransaction.Rollback(); }
    }
    public async Task  CompleteAsync()
    {
         await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}