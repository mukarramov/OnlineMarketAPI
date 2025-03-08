using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Interface;

public interface IUserService
{
    Task<Users?> Create(string name, string email, string password, Role role);
    Task<IEnumerable<Users?>> GetAll();
    Task<Users> GetById(int userId);
    Task<bool> Delete(int userId);
    Task<bool> Update(int id, string name, string email, string password, Role role);
}