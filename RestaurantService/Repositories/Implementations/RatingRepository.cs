using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(DbContext context) : base(context)
    {
    }

    public IEnumerable<Rating> GetRatingsWithFullInfo()
    {
        return Entities
            .Include(rating => rating.Author)
            .Include(rating => rating.Restaurant)
            .ToList();
    }

    public Rating? GetRatingWithFullInfoOrDefault(int id)
    {
        return GetRatingsWithFullInfo().FirstOrDefault(rating => rating.Id == id);
    }
}