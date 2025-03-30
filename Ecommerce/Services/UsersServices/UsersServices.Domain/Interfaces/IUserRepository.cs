namespace Ecommerce.Services.UsersServices.UsersServices.Domain.Interfaces.IUserRepository
{
    public interface IUserRepository
    {
        Task<Ecommerce.Services.UsersServices.UsersServices.Domain.Entities.User?> GetByEmailAsync(string email);
        Task AddAsync(Ecommerce.Services.UsersServices.UsersServices.Domain.Entities.User user);
        Task UpdateAsync(Ecommerce.Services.UsersServices.UsersServices.Domain.Entities.User user);
        Task DeleteAsync(Guid userId);
        Task UpdatePassword(string email, string passwordHash);
        Task UpdateName(string name);

    }
}
