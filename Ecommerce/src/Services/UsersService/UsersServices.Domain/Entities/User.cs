using System.Security.Cryptography;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.Entities
{
    namespace Ecommerce.src.Services.UsersService.UsersService.Domain.Entities
    {
        public class User
        {
            private HMACSHA3_256 _hmac;
            public Guid userId { get; private set; }
            public string Email { get; private set; }
            public string Name { get; private set; }
            public string _passwordHash { get; private set; }

            protected User()
            {
                Email = string.Empty;
                Name = string.Empty;
                _passwordHash = string.Empty;
                _hmac = new HMACSHA3_256();
            }

            public User(string email, string passwordHash)
            {
                userId = Guid.NewGuid();
                Email = email;
                _passwordHash = passwordHash;
                Name = string.Empty;
                _passwordHash = passwordHash;
                _hmac = new HMACSHA3_256();
            }
}
    }
}