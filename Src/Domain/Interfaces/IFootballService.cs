namespace Domain.Interfaces;
public interface IFootballService<T> where T : class
{
    public IEnumerable<T> FindAll();
    public T Find(int id);

    public T Add(T data );
    public T Update(T data, int id);

}
