using OnlineMarket.Models;

namespace OnlineMarket.Interface;

public interface IJwtService
{
    string GenerateToken(Users user);
}