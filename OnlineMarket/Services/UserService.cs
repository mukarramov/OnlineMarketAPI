using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Common;
using OnlineMarket.Configuration;
using OnlineMarket.Interface;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;
using OnlineMarket.Repositoryes;

namespace OnlineMarket.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<Users?> Create(string name, string email, string password, Role role)
    {
        var newUser = new Users();
        await _userRepository.AddAsync(name, email, password, role);
        return newUser;
    }

    public async Task<IEnumerable<Users?>> GetAll()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<Users> GetById(int userId)
    {
        return await _userRepository.GetByAsync(userId) ?? throw new Exception("not found!");
    }

    public Task<bool> Delete(int userId)
    {
        bool check;
        _userRepository.DeleteAsync(userId);
        check = true;

        return Task.FromResult(check);
    }

    public async Task<bool> Update(int id, string name, string email, string password, Role role)
    {
        bool check;
        var updateUser = await _userRepository.GetByIdAsync(id);
        if (updateUser == null)
        {
            throw new Exception("user not found!");
        }

        updateUser.Name = name;
        updateUser.Email = email;
        updateUser.PasswordHash = password;
        updateUser.Role = role;

        check = true;

        return await Task.FromResult(check);
    }
}