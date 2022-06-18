using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(DbContext context) : base(context)
    {
    }
}