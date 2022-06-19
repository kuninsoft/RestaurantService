using Microsoft.AspNetCore.Mvc;
using RestaurantService.Models;
using RestaurantService.Services;

namespace RestaurantService.Controllers;

[Route("api/Restaurants")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RestaurantsController> _logger;
    
    public RestaurantsController(IUnitOfWork unitOfWork, ILogger<RestaurantsController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(_unitOfWork.Restaurants.GetRestaurantsWithFullInfo());
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Restaurant? restaurant = _unitOfWork.Restaurants.GetRestaurantWithFullInfoOrDefault(id);

        if (restaurant is null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Restaurant restaurant)
    {
        try
        {
            Restaurant newRestaurant = _unitOfWork.Restaurants.Add(restaurant);
            _unitOfWork.Save();
            
            _logger.LogInformation("Restaurants | Add successful");
            
            return Created($"api/Restaurants/{newRestaurant.Id}", newRestaurant);
        }
        catch (Exception e)
        {
            _logger.LogError($"Restaurants | {e.Message}");
            
            return StatusCode(500);
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] Restaurant restaurant)
    {
        try
        {
            Restaurant result = _unitOfWork.Restaurants.Update(restaurant);
            _unitOfWork.Save();
            
            _logger.LogInformation("Restaurants | Update successful");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Restaurants | {e.Message}");
            
            return StatusCode(500);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _unitOfWork.Restaurants.Delete(id);
            _unitOfWork.Save();
            
            _logger.LogInformation("Restaurants | Delete successful");
            
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Restaurants | {e.Message}");
            
            return StatusCode(500);
        }
    }
}