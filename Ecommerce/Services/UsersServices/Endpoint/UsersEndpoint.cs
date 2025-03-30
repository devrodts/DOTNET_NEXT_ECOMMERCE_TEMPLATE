using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Ecommerce.Services.UsersServices.Endpoint
{
    public static class UsersEndpoint
    {
        public static RouteGroupBuilder MapUsersEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/users");

            group.MapGet("/", () => "Lista de usuários")
                .WithName("GetUsers");

            group.MapGet("/{id}", (int id) => $"Detalhes do usuário com id: {id}")
                .WithName("GetUserById");

            return group;
        }
    }
}