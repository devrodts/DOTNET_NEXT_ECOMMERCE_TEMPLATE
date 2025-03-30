using System.Collections.Generic;
using Ecommerce.Services.UsersServices.Domain.Common;

namespace Ecommerce.Services.UsersServices.Domain.ValueObjects
{
    public class UserFullName : ValueObject
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string MiddleName { get; init; }

        // Parâmetros obrigatórios antes dos opcionais.
        public UserFullName(string firstName, string lastName, string middleName = "")
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return MiddleName;
        }
    }
}