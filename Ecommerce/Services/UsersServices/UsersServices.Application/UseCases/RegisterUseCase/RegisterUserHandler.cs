using System;
using System.Threading.Tasks;
using Ecommerce.Services.UsersServices.Domain.Interfaces;
using Ecommerce.Services.UsersServices.Domain.Entities;
using Ecommerce.Services.UsersServices.Application.UseCases.RegisterUseCase;

namespace Ecommerce.Services.UsersServices.Application.UseCases.RegisterUseCase
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task HandleAsync(RegisterUserCommand command)
        {
            if (await _userRepository.GetByEmailAsync(command.Email) != null)
                throw new InvalidOperationException("Email is already registered.");

            string passwordHash = _passwordHasher.HashPassword(command.Password);
            var user = new User(command.Email, passwordHash);

            await _userRepository.AddAsync(user);
        }
    }
}