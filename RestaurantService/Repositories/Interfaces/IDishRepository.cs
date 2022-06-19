using RestaurantService.Models;

namespace RestaurantService.Repositories.Interfaces;

public interface IDishRepository : IBaseRepository<Dish>
{
    IEnumerable<Dish> GetDishesWithRestaurants();
    Dish? GetDishWithRestaurantOrDefault(int id);
}