﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Services.UsersServices // Note que não está mais em "Ecommerce"
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

            app.UseHttpsRedirection();
            app.Run();
        }
    }
}