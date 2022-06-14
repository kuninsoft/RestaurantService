using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;

namespace RestaurantService.Services;

public class MainContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}