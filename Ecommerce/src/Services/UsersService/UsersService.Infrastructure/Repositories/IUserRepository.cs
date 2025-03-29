namespace Ecommerce.src.Services.UsersService.UsersService.Infrastructure.Repositories
{
    public interface IUserRepository
    {

        public async Task<User?> GetUserAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId cannot be empty", nameof(userId));

            try
            {
                using var context = new ApplicationDbContext();
                var user = await context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error retrieving user with ID {userId}", ex);
            }
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        protected string UpdatePassword(string password, string newPassword)
        {
            if (password == string.Empty)
                throw new ArgumentException(password, nameof(password));
            if (password == newPassword)
                throw new ArgumentException(password, nameof(newPassword));

            try
            {
                var updatedPassword = newPassword;
                return newPassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
    }
}
