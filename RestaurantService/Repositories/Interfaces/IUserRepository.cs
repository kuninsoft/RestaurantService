using RestaurantService.Models;

namespace RestaurantService.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    IEnumerable<User> GetUsersWithRatings();
    User? GetUserWithRatingOrDefault(int id);
    bool IsModerator(int id);
    bool Exists(string username);
    User? ReturnUserWithCredentialsOrDefault(string username, string password);
}