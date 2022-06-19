using RestaurantService.Models;

namespace RestaurantService.Repositories.Interfaces;

public interface IRestaurantRepository : IBaseRepository<Restaurant>
{
    IEnumerable<Restaurant> GetRestaurantsWithFullInfo();
    Restaurant? GetRestaurantWithFullInfoOrDefault(int id);
    decimal GetRestaurantAverageRating(Restaurant restaurant);
    IEnumerable<Restaurant> GetBestRatedRestaurants(int amount);
    
}