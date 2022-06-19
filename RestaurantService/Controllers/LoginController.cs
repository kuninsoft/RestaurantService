using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantService.Models;
using RestaurantService.Services;

namespace RestaurantService.Controllers;

[Route("api/Login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ITokenGenerationService _tokenGenerationService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LoginController> _logger;

    public LoginController(ITokenGenerationService tokenGenerationService, IUnitOfWork unitOfWork,
        ILogger<LoginController> logger)
    {
        _tokenGenerationService = tokenGenerationService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserCredentialsDto userCredentials)
    {
        User? user = TryAuthenticate(userCredentials);

        if (user is null)
        {
            return NotFound();
        }
        
        string token = _tokenGenerationService.GenerateToken(user);
        return Ok(token);
    }

    private User? TryAuthenticate(UserCredentialsDto userCredentials)
    {
        return _unitOfWork.Users.ReturnUserWithCredentialsOrDefault(userCredentials.Username, userCredentials.Password);
    }
}