using RestaurantService.Models;

namespace RestaurantService.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    User FindUserByUsername(string name);
    User? FindUserByUsernameOrDefault(string name);
    IEnumerable<User> GetUsersWithRatings();
}