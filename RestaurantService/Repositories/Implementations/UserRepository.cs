using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public User FindUserByUsername(string name)
    {
        return GetUsersWithRatings().First(user => user.Username == name);
    }

    public User? FindUserByUsernameOrDefault(string name)
    {
        return GetUsersWithRatings().FirstOrDefault(user => user.Username == name);
    }

    public IEnumerable<User> GetUsersWithRatings()
    {
        return Entities.Include(user => user.RatingsWritten).ToList();
    }
}