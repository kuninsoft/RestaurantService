using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(DbContext context) : base(context)
    {
    }

    public IEnumerable<Restaurant> GetRestaurantsWithFullInfo()
    {
        return Entities
            .Include(restaurant => restaurant.Menu)
            .Include(restaurant => restaurant.Ratings)
            .ToList();
    }

    public Restaurant? GetRestaurantWithFullInfoOrDefault(int id)
    {
        return GetRestaurantsWithFullInfo().FirstOrDefault(restaurant => restaurant.Id == id);
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