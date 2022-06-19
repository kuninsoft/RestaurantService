using RestaurantService.Models;

namespace RestaurantService.Repositories.Interfaces;

public interface IRatingRepository : IBaseRepository<Rating>
{
    IEnumerable<Rating> GetRatingsWithFullInfo();
    Rating? GetRatingWithFullInfoOrDefault(int id);
}