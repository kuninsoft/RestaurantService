using Microsoft.EntityFrameworkCore;
using RestaurantService.Models;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Repositories.Implementations;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
    
    public IEnumerable<User> GetUsersWithRatings()
    {
        return Entities.Include(user => user.RatingsWritten).ToList();
    }

    public User? GetUserWithRatingOrDefault(int id)
    {
        return GetUsersWithRatings().FirstOrDefault(user => user.Id == id);
    }

    public bool IsModerator(int id)
    {
        User? user = Get(id);
        
        if (user is null) return false;

        return user.Role == Role.Moderator;
    }
}