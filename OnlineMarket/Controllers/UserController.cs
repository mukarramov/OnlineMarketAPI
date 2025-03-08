using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Interface;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public Task<Users> Create(string name, string email, string password, Role role)
    {
        _userService.Create(name, email, password, role);
        var newUser = new Users
        {
            Name = name,
            Email = email,
            PasswordHash = password,
            Role = role
        };
        return Task.FromResult(newUser);
    }

    [HttpGet]
    public async Task<IEnumerable<Users?>> GetAll()
    {
        return await _userService.GetAll();
    }

    [HttpGet]
    public async Task<Users> GetById(int id)
    {
        return await _userService.GetById(id);
    }

    [HttpPut]
    public async Task<bool> Update(int id, string name, string email, string password, Role role)
    {
        return await _userService.Update(id, name, email, password, role);
    }

    [HttpDelete]
    public async Task<bool> Delete(int id)
    {
        return await _userService.Delete(id);
    }
}