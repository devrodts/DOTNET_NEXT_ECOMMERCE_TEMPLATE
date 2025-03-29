namespace Ecommerce.src.Services.UsersService.UsersServices.Application.Dtos
{
    public record UpdateUserDTO(
        string? email,
        string? password,
        string? firstName,
        string ? lastName
    );
}