namespace Ecommerce.Services.UsersServices.UsersServices.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}