using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models;

public class Restaurant
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    
    public ICollection<Dish?> Menu { get; set; } = new List<Dish?>();
    public ICollection<Rating?> Ratings { get; set; } = new List<Rating?>();
}