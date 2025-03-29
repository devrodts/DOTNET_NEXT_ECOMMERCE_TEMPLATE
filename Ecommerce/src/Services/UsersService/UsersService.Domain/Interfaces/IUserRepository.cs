using Ecommerce.src.Services.UsersService.UsersService.Domain.Entities;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid userId);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task DeleteAsync(Guid userId);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
