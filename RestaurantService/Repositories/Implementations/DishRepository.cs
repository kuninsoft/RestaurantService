using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class DishRepository : BaseRepository<Dish>, IDishRepository
{
    public DishRepository(DbContext context) : base(context)
    {
    }
}