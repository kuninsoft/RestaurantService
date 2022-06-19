using System.ComponentModel.DataAnnotations;

namespace RestaurantService.Models;

public class Rating
{
    [Key]
    public int Id { get; set; }
    [Required, Range(0, 5)]
    public decimal Score { get; set; }
    public string? Comment { get; set; }
    
    [Required]
    public int AuthorId { get; set; }
    public User? Author { get; set; }
    
    [Required]
    public int RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}