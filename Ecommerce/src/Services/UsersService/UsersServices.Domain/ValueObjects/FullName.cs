using Ecommerce.src.Services.UsersService.UsersService.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.ValueObject
{
    public class UserFullName : ValueObject
    {
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        public string LastName { get; init; }

        public UserFullName(string firstName, string middleName = "", string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }  
    }
}