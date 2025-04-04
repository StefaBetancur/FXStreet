using Domain.Entities;
using Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkDiver;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly FootballContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(FootballContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity, int id)
    {
        if (entity != null)
        {
            // Check if the entity is already being tracked
            var existingEntity = _dbSet.Find(id);
            if (existingEntity != null)
            {
                // If it is being tracked, update its properties
                _dbSet.Entry(existingEntity).CurrentValues.SetValues(entity);
               
            }
            else
            {
                // If it is not being tracked, attach the entity and mark it as modified
                _dbSet.Update(entity);
            }
        }
    }

    public void Delete(int id)
    {
        T entity = _dbSet.Find(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}
