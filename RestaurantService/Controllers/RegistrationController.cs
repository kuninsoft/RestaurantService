using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantService.Models;
using RestaurantService.Services;

namespace RestaurantService.Controllers;

[Route("api/Register")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenGenerationService _tokenGenerationService;
    private readonly ILogger<RegistrationController> _logger;

    public RegistrationController(IUnitOfWork unitOfWork, ITokenGenerationService tokenGenerationService, ILogger<RegistrationController> logger)
    {
        _unitOfWork = unitOfWork;
        _tokenGenerationService = tokenGenerationService;
        _logger = logger;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Register([FromBody] UserCredentialsDto userCredentials)
    {
        try
        {
            if (_unitOfWork.Users.Exists(userCredentials.Username))
            {
                return BadRequest();
            }
            
            User newUser = _unitOfWork.Users.Add(new User
            {
                Username = userCredentials.Username,
                Password = userCredentials.Password,
                Role = "User"
            });
            
            _unitOfWork.Save();
            string token = _tokenGenerationService.GenerateToken(newUser);

            _logger.LogInformation($"Registered a user! {userCredentials.Username}");
            return Ok(token);
        }
        catch (Exception e)
        {
            _logger.LogError($"Users | Registration: {e.Message}");

            return StatusCode(500);
        }
    }
}