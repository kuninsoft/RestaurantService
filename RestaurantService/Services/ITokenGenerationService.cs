using RestaurantService.Models;

namespace RestaurantService.Services;

public interface ITokenGenerationService
{
    string GenerateToken(User user);
}