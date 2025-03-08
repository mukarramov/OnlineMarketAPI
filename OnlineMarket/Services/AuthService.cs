using System.Text;
using OnlineMarket.Interface;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<string?> AuthenticateAsync(string userName, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(userName);

        if (user == null)
        {
            throw new UnauthorizedAccessException("User not found.");
        }

        var d = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

        if (!d)
        {
            throw new UnauthorizedAccessException("Incorrect password.");
        }


        return _jwtService.GenerateToken(user);
    }

    public async Task<bool> RegisterAsync(Users user)
    {
        bool check;
        await _userRepository.AddAsyncFromBody(user);
        check = true;
        return check;
    }
}