using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.System.Guid;

namespace Ecommerce.Services.UsersServices.Endpoint
{
    public static class UsersEndpoint
    {
        public static RouteGroupBuilder MapUsersEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/users");

            group.MapGet("/", () => "Lista de usuários")
                .WithName("GetUsers");

            group.MapGet("/{id}", (Guid userId)
            {
                Console.WriteLine("Get user by id route");
                return "Get user by id route"
            });

            group.MapPost("/", () 
            {
                
            })
            return group;
        }
    }
}