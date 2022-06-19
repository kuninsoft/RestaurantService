using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class DishRepository : BaseRepository<Dish>, IDishRepository
{
    public DishRepository(DbContext context) : base(context)
    {
    }

    public IEnumerable<Dish> GetDishesWithRestaurants()
    {
        return Entities
            .Include(dish => dish.Restaurant)
            .ToList();
    }

    public Dish? GetDishWithRestaurantOrDefault(int id)
    {
        return GetDishesWithRestaurants().FirstOrDefault(dish => dish.Id == id);
    }
}