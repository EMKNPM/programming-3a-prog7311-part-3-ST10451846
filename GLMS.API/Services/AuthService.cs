using GLMS.API.Data;
using GLMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GLMS.API.Services
{
    public class AuthService
    {
        private readonly GLMSDbContext _context;
        private readonly PasswordService _passwordService;
        private readonly JwtService _jwtService;

        public AuthService(
            GLMSDbContext context,
            PasswordService passwordService,
            JwtService jwtService)
        {
            _context = context;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        // REGISTER
        public async Task<User> Register(string username, string password)
        {
            var exists = await _context.Users
                .AnyAsync(u => u.Username == username);

            if (exists)
                throw new Exception("User already exists");

            var user = new User
            {
                Username = username,
                PasswordHash = _passwordService.HashPassword(password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // LOGIN
        public async Task<string> Login(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                throw new Exception("Invalid username");

            var valid = _passwordService.VerifyPassword(password, user.PasswordHash);

            if (!valid)
                throw new Exception("Invalid password");

            return _jwtService.GenerateToken(user);
        }
    }
}