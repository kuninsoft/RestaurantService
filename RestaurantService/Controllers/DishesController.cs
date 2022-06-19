using Microsoft.AspNetCore.Mvc;
using RestaurantService.Models;
using RestaurantService.Services;

namespace RestaurantService.Controllers;

[Route("api/Dishes")]
[ApiController]
public class DishesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DishesController> _logger;
    
    public DishesController(IUnitOfWork unitOfWork, ILogger<DishesController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(_unitOfWork.Dishes.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Dish? dish = _unitOfWork.Dishes.GetDishWithRestaurantOrDefault(id);

        if (dish is null)
        {
            return NotFound();
        }

        return Ok(dish);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Dish dish)
    {
        try
        {
            Dish result = _unitOfWork.Dishes.Add(dish);
            _unitOfWork.Save();

            return Created($"api/Dishes/{result.Id}", result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Dishes | Add: {e.Message}");
            
            return StatusCode(500);
        }
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] Dish dish)
    {
        try
        {
            Dish result = _unitOfWork.Dishes.Update(dish);
            _unitOfWork.Save();

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"Dishes | Update: {e.Message}");
            
            return StatusCode(500);
        }
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _unitOfWork.Dishes.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Dishes | Delete: {e.Message}");
            
            return StatusCode(500);
        }
    }
}