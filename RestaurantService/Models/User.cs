using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
    [Required]
    public Role Role { get; set; }

    public ICollection<Rating?> RatingsWritten { get; set; } = new List<Rating?>();
}