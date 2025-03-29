using System;
using System.Collections.Generic;
using Ecommerce.src.Services.UsersService.UsersService.Domain.SeedWork;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.AggregatesModel.OrderAggregate
{
	public class Address : ValueObject
	{
		public string Street { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }
		public string Country { get; private set; }
		public string ZipCode { get; private set; }

		protected Address() { }

		public Address(string street, string city, string state, string country, string zipCode)
		{
			if (string.IsNullOrWhiteSpace(street))
				throw new ArgumentException("Street is required.", nameof(street));
			if (string.IsNullOrWhiteSpace(city))
				throw new ArgumentException("City is required.", nameof(city));
			if (string.IsNullOrWhiteSpace(state))
				throw new ArgumentException("State is required.", nameof(state));
			if (string.IsNullOrWhiteSpace(country))
				throw new ArgumentException("Country is required.", nameof(country));
			if (string.IsNullOrWhiteSpace(zipCode))
				throw new ArgumentException("ZipCode is required.", nameof(zipCode));

			Street = street;
			City = city;
			State = state;
			Country = country;
			ZipCode = zipCode;
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Street;
			yield return City;
			yield return State;
			yield return Country;
			yield return ZipCode;
		}
	}
}
