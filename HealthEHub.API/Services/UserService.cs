using HealthEHub.API.Data;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace HealthEHub.API.Services
{
    public class UserService(HealthEHubContext context)
    {
        public async Task<User> Register(string username, string email, string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { Username = username, Email = email, PasswordHash = passwordHash };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Invalid username or password");
            }

            return user;
        }

    }
}
