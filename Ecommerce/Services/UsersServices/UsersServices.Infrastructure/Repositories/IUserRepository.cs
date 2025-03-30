using System;
using System.Threading.Tasks;
using Ecommerce.Services.UsersServices;
using Ecommerce.Services.UsersServices.UsersServices.Domain.Entities;

namespace Ecommerce.Services.UsersServices.UsersServices.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);
        void UpdateName(string name);
        string UpdatePassword(string password, string newPassword);
         Task<User?> GetByEmailAsync(string email);

        // Task<User?> GetUserAsync(Guid userId);
      
        Task AddAsync(User user);

    }
}
