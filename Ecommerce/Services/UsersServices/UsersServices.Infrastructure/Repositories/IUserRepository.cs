using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Services.UsersServices.Domain.Entities;
using Ecommerce.Services.UsersServices.Domain.Interfaces;

namespace Ecommerce.Services.UsersServices.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
        
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task UpdatePassword(string email, string passwordHash)
        {
            var user = await GetByEmailAsync(email);
            if (user != null)
            {
                user.UpdatePasswordHash(passwordHash);
                await _context.SaveChangesAsync();
            }
        }
    
        public async Task UpdateName(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user != null)
            {
                user.UpdateName(name);
                await _context.SaveChangesAsync();
            }
        }
    }
}