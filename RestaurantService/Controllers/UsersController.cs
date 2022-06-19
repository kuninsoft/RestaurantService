using Microsoft.AspNetCore.Mvc;
using RestaurantService.Models;
using RestaurantService.Services;

namespace RestaurantService.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private IUnitOfWork _unitOfWork;
    private ILogger<UsersController> _logger;

    public UsersController(IUnitOfWork unitOfWork, ILogger<UsersController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(_unitOfWork.Users.GetUsersWithRatings());
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        User? user = _unitOfWork.Users.GetUserWithRatingOrDefault(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        try
        {
            User newUser = _unitOfWork.Users.Add(user);
            _unitOfWork.Save();

            return Created($"api/Users/{newUser.Id}", newUser);
        }
        catch (Exception e)
        {
            _logger.LogError($"Users | Add: {e.Message}");

            return StatusCode(500);
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] User user)
    {
        try
        {
            User result = _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError($"Users | Update: {e.Message}");

            return StatusCode(500);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.Save();

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"Users | Delete: {e.Message}");

            return StatusCode(500);
        }
    }
}