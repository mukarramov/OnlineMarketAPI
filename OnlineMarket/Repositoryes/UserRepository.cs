using Microsoft.EntityFrameworkCore;
using OnlineMarket.Context;
using OnlineMarket.Interface;
using OnlineMarket.Models;
using OnlineMarket.Models.Enums;

namespace OnlineMarket.Repositoryes;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Users?> GetByAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<IEnumerable<Users?>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(string name, string email, string password, Role role)
    {
        var newUser = new Users();
        newUser.Name = name;
        newUser.Email = email;
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        newUser.PasswordHash = hashPassword;
        newUser.Role = role;

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }

    public void Update(Users users)
    {
        _context.Users.Update(users);
    }

    public void DeleteAsync(int userId)
    {
        var findById = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (findById == null)
        {
            throw new Exception("user not found!");
        }

        _context.Users.Remove(findById);
        _context.SaveChanges();
    }

    public async Task<Users?> GetByIdAsync(int userId)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }
}