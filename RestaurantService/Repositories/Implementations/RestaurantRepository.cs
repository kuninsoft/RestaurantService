using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(DbContext context) : base(context)
    {
    }

    public Restaurant FindRestaurantByName(string name)
    {
        return GetRestaurantsWithFullInfo().First(restaurant => restaurant.Name == name);
    }

    public Restaurant? FindRestaurantByNameOrDefault(string name)
    {
        return GetRestaurantsWithFullInfo().FirstOrDefault(restaurant => restaurant.Name == name);
    }

    public IEnumerable<Restaurant> GetRestaurantsWithFullInfo()
    {
        return Entities
            .Include(restaurant => restaurant.Menu)
            .Include(restaurant => restaurant.Ratings)
            .ToList();
    }

    public decimal GetRestaurantAverageRating(Restaurant restaurant)
    {
        return restaurant.Ratings.Average(rating => rating.Score);
    }
    

    public IEnumerable<Restaurant> GetBestRatedRestaurants(int amount)
    {
        return Entities
            .ToDictionary(restaurant => restaurant, GetRestaurantAverageRating)
            .OrderByDescending(restaurantAndAvgRating => restaurantAndAvgRating.Value)
            .Take(amount)
            .Select(item => item.Key)
            .ToList();
    }
}