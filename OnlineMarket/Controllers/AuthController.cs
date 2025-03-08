using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Interface;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Users user)
    {
        var token = await _authService.AuthenticateAsync(user.Name, user.PasswordHash);
        if (token == null)
        {
            throw new Exception("not found!");
        }

        return Ok(token);
    }

    [HttpPost("register/user")]
    public async Task<IActionResult> RegisterUser([FromBody] Users user)
    {
        var success = await authService.RegisterAsync(user);
        if (!success)
        {
            return BadRequest("not found!");
        }

        return Ok(success);
    }

    [HttpPost("register/admin")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] Users user)
    {
        var success = await authService.RegisterAsync(user);
        if (!success)
        {
            return BadRequest("not found!");
        }

        return Ok(success);
    }
}