using System.Linq.Expressions;

namespace RestaurantService.Repositories;

public interface IBaseRepository<T> where T : class
{
    T? Find(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    T Add(T entity); 
    void Delete(T entity);
}