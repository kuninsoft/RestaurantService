using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(DbContext context) : base(context)
    {
    }
}