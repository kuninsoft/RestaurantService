using RestaurantService.Repositories.Implementations;
using RestaurantService.Repositories.Interfaces;

namespace RestaurantService.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly MainContext _context;
    
    public IUserRepository Users { get; set; }
    public IRestaurantRepository Restaurants { get; set; }
    public IDishRepository Dishes { get; set; }
    public IRatingRepository Ratings { get; set; }

    public UnitOfWork(MainContext context)
    {
        _context = context;
        
        Users = new UserRepository(context);
        Restaurants = new RestaurantRepository(context);
        Dishes = new DishRepository(context);
        Ratings = new RatingRepository(context);
    }
    
    public Task<int> Save() => _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}