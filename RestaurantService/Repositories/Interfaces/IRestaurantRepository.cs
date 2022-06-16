using RestaurantService.Models;

namespace RestaurantService.Repositories.Interfaces;

public interface IRestaurantRepository : IBaseRepository<Restaurant>
{
    Restaurant FindRestaurantByName(string name);
    Restaurant? FindRestaurantByNameOrDefault(string name);
    IEnumerable<Restaurant> GetRestaurantsWithFullInfo();
    decimal GetRestaurantAverageRating(Restaurant restaurant);
    IEnumerable<Restaurant> GetBestRatedRestaurants(int amount);
    
}