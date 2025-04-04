using Domain.Interfaces;
using Domain.Interfaces.Infrastructure;

namespace Domain;
public class FootballService<T>: IFootballService<T> where T : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<T> _repository;

    public FootballService(IUnitOfWork unitOfWork, IRepository<T> repository) 
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public IEnumerable<T> FindAll()
    {  
       return _repository.GetAll();
    }
    public T Find(int id)
    {
        return _repository.GetById(id);
    }

    public T Add(T data) 
    {
        _repository.Add(data);
        _unitOfWork.CompleteAsync();
        return data;
    }
    public T Update(T data, int id) 
    {
        _repository.Update(data, id);
        _unitOfWork.CompleteAsync();
        return data;
    }

}
