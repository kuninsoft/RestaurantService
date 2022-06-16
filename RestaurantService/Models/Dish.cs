using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models;

public class Dish
{
    [Key] 
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}