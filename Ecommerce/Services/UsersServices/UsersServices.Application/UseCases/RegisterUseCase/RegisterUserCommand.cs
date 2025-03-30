namespace Ecommerce.Services.UsersServices.Application.UseCases.RegisterUseCase
{
    public class RegisterUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}