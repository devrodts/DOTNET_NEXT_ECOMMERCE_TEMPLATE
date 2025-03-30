using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Ecommerce.Services.UsersServices.Endpoint; // Using atualizado

namespace Ecommerce.Services.UsersServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapUsersEndpoints();
            app.Run();
        }
    }
}