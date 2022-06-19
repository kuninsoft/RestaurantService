using Microsoft.AspNetCore.Mvc;
using RestaurantService.Models;
using RestaurantService.Services;

namespace RatingService.Controllers;

[Route("api/Ratings")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RatingsController> _logger;
    
    public RatingsController(IUnitOfWork unitOfWork, ILogger<RatingsController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(_unitOfWork.Ratings.GetRatingsWithFullInfo());
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Rating? rating = _unitOfWork.Ratings.GetRatingWithFullInfoOrDefault(id);

        if (rating is null)
        {
            return NotFound();
        }

        return Ok(rating);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Rating rating)
    {
        try
        {
            Rating newRating = _unitOfWork.Ratings.Add(rating);
            _unitOfWork.Save();
            
            _logger.LogInformation("Ratings | Add successful");
            
            return Created($"api/Ratings/{rating.Id}", rating);
        }
        catch (Exception e)
        {
            _logger.LogError($"Ratings | {e.Message}");
            
            return StatusCode(500);
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] Rating rating)
    {
        try
        {
            Rating result = _unitOfWork.Ratings.Update(rating);
            _unitOfWork.Save();
            
            _logger.LogInformation("Ratings | Update successful");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Ratings | {e.Message}");
            
            return StatusCode(500);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _unitOfWork.Ratings.Delete(id);
            _unitOfWork.Save();
            
            _logger.LogInformation("Ratings | Delete successful");
            
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Ratings | {e.Message}");
            
            return StatusCode(500);
        }
    }
}