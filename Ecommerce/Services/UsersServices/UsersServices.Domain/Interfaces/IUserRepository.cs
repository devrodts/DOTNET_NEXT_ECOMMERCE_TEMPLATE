using System;
using System.Threading.Tasks;
using Ecommerce.Services.UsersServices.Domain.Entities;

namespace Ecommerce.Services.UsersServices.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid userId);
        Task UpdatePassword(string email, string passwordHash);
        Task UpdateName(string name);
    }
}