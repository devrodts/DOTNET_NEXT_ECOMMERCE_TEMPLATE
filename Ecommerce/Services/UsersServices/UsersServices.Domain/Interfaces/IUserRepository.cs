using Ecommerce.Services.UsersServices.UsersServices.Domain.Entities;
namespace Ecommerce.Services.UsersServices.UsersServices.Domain.Interfaces.IUserRepository
{

    private User user;

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
