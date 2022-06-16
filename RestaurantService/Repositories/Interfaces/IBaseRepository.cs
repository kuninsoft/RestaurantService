using System.Linq.Expressions;

namespace RestaurantService.Repositories;

public interface IBaseRepository<T> where T : class
{
    T? Get(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
    T Add(T entity); 
    void Delete(T entity);
}