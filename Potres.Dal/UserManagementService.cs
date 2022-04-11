
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Potres.Dal.Model;
using Potres.Contracting.Security;
using System.Collections.Generic;

namespace Potres.WebApi.Util.Security
{
    public class UserManagementService : IUserManagementService
    {
        private readonly PotresContext context;
        private readonly IPasswordHasher<string> passwordHasher;

        public UserManagementService(PotresContext context, IPasswordHasher<string> passwordHasher)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
        }

        public async Task<UserDto> GetUserData(string username)
        {
            var user = await context.User
                                    .Where(c => c.Name == username)
                                    .Select(c => new UserDto
                                    {
                                    Id = c.Id,
                                    Username = c.Name,                                    
                                    FirstName = c.FirstName,
                                    LastName = c.LastName,                                                               
                                    })
                                    .SingleAsync(); //neka baci iznimku ako bude pozvano na korisniku koji ne postoji
            return user;
        }

        public async Task<List<RoleDto>> GetUserRoles(string username)
        {
            var user = await context.UserRole
                                    .Where(c => c.User.Name == username)
                                    .Select(c => new RoleDto
                                    {
                                        Id = c.RoleId,
                                        Name = c.Role.Name
                                    })
                                    .ToListAsync(); //neka baci iznimku ako bude pozvano na korisniku koji ne postoji
            return user;
        }

        public async Task<bool> IsValidRefreshToken(string username, string refreshToken)
        {
            bool isValid = await context.RefreshToken
                                        .Where(rt => rt.User.Name == username)
                                        .Where(rt => rt.Token == refreshToken)
                                        .Where(rt => DateTime.UtcNow <= rt.Expires)
                                        .AnyAsync();
            return isValid;

        }

        public async Task<bool> IsValidUser(string username, string password)
        {
            bool valid = false;
            string hash = await context.User
                                       .Where(u => u.Name == username)
                                       .Select(u => u.Password)
                                       .FirstOrDefaultAsync();
            if (hash != null)
            {
                valid = passwordHasher.VerifyHashedPassword(username, hash, password) != PasswordVerificationResult.Failed;
            }
            return valid;
        }

        public async Task ReplaceRefreshToken(string username, string oldRefreshToken, string newRefreshToken, int validDays)
        {
            var token = await context.RefreshToken
                                     .Where(rt => rt.User.Name == username)
                                     .Where(rt => rt.Token == oldRefreshToken)
                                     .FirstOrDefaultAsync();
            token.Token = newRefreshToken;
            token.Expires = DateTime.Now.AddDays(validDays);
            await context.SaveChangesAsync();
        }

        public async Task AddRefreshToken(string username, string refreshToken, int validDays)
        {
            int userId = await context.User
                                      .Where(u => u.Name == username)
                                      .Select(u => u.Id)
                                      .FirstAsync();

            var token = new RefreshToken
            {
                UserId = userId,
                Token = refreshToken,
                Expires = DateTime.Now.AddDays(validDays)
            };

            context.Add(token);           
            await context.SaveChangesAsync();
        }
    }
}
