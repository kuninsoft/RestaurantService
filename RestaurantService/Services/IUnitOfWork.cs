using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Services;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; set; }
    IRestaurantRepository Restaurants { get; set; }
    IDishRepository Dishes { get; set; }
    IRatingRepository Ratings { get; set; }

    Task<int> Save();
}