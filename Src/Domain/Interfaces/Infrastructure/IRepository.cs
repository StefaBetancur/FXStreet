namespace Domain.Interfaces.Infrastructure;
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity, int id);
}
