namespace Domain.Interfaces.Infrastructure;
public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    Task CompleteAsync();
    void CreateTransaction();
}