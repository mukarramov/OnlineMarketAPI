using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Interface;

public interface IAuthService
{
    Task<string?> AuthenticateAsync(string userName, string password);
    Task<bool> RegisterAsync(Users user);
}