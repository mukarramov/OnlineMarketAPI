using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Interface;

public interface IUserRepository
{
    Task<Users?> GetByAsync(int userId);
    Task<IEnumerable<Users?>> GetAllAsync();
    Task AddAsync(string name, string email, string password, Role role);
    void Update(Users users);
    void DeleteAsync(int userId);
    Task<Users?> GetByIdAsync(int userId);
}