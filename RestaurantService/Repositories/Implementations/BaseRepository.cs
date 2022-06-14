using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RestaurantService.Repositories.Implementations;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected DbSet<T> Entities { get; }

    public BaseRepository(DbContext context)
    {
        Entities = context.Set<T>();
    }
    
    public T? Find(int id)
    {
        return Entities.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return Entities.ToList();
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
    {
        return Entities.Where(predicate);
    }

    public T Add(T entity)
    {
        return Entities.Add(entity).Entity;
    }

    public void Delete(T entity)
    {
        Entities.Remove(entity);
    }
}