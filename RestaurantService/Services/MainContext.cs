using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;

namespace RestaurantService.Services;

public sealed class MainContext : DbContext
{
    private string DbPath { get; set; }
    
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<User> Users { get; set; }
    
    public MainContext()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, "restaurants.db");
        
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite($"Data Source={DbPath}");
}