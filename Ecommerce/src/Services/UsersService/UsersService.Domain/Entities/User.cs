namespace Ecommerce.src.Services.UsersService.UsersService.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }

        protected User()
        {
            Email = string.Empty;
            Name = string.Empty;
            PasswordHash = string.Empty;
        }

        public User(string email, string passwordHash)
        {
            UserId = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            Name = string.Empty;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }


    }
}
