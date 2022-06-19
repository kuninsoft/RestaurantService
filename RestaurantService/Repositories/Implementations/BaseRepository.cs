using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected DbSet<T> Entities { get; }

    public BaseRepository(DbContext context)
    {
        Entities = context.Set<T>();
    }
    
    public T? Get(int id)
    {
        return Entities.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return Entities.ToList();
    }

    public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
    {
        return Entities.Where(predicate);
    }

    public T Add(T entity)
    {
        return Entities.Add(entity).Entity;
    }

    public T Update(T entity)
    {
        return Entities.Update(entity).Entity;
    }

    public void Delete(int id)
    {
        T? entity = Get(id);

        if (entity is null) return;
        
        Entities.Remove(entity);
    }
}