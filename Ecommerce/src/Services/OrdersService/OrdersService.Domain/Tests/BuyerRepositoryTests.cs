namespace Ecommerce.src.Services.OrdersService.OrdersService.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Ecommerce.src.Services.OrdersService.OrdersService.Domain.AggregatesModel.BuyerAggregate;
    using Ecommerce.src.Services.OrdersService.OrdersService.Domain.SeedWork;
    using Ecommerce.src.Services.UsersService.UsersService.Domain.AggregatesModel.BuyerAggregate;

    public class BuyerRepositoryTests
    {
        [Fact]
        public async Task FindByIdAsync_ReturnsBuyer_WhenBuyerExists()
        {
            var expectedId = Guid.NewGuid();
            var expectedBuyer = Buyer(expectedId, "some-identity");

            var repository = new InMemoryBuyerRepository();
            repository.Add(expectedBuyer)
            var buyer = await repository.FindByIdAsync(expectedId);

            Assert.NotNull(buyer);
            Assert.Equal(expectedId, buyer.Id);
        }

        private Buyer Buyer(Guid expectedId, string v)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task FindByIdAsync_ReturnsNull_WhenBuyerDoesNotExist()
        {

            var repository = new InMemoryBuyerRepository();

            var buyer = await repository.FindByIdAsync(Guid.NewGuid());

            Assert.Null(buyer);
        }
    }

    public class InMemoryBuyerRepository : IBuyerRepository
    {
        private readonly Dictionary<Guid, Buyer> _buyers = new();

        public IUnitWork UnitWork => throw new NotImplementedException();

        public Buyer Add(Buyer buyer)
        {
            if (buyer == null)
                throw new ArgumentNullException(nameof(buyer));

            _buyers[buyer.Id] = buyer;
            return buyer;
        }

        public Buyer Update(Buyer buyer)
        {
            if (buyer == null)
                throw new ArgumentNullException(nameof(buyer));

            _buyers[buyer.Id] = buyer;
            return buyer;
        }

        public Task<Buyer?> FindAsync(string buyerIdentityGuid)
        {
            var buyer = _buyers.Values.FirstOrDefault(b => b.IdentityGuid == buyerIdentityGuid);
            return Task.FromResult(buyer);
        }

        public Task<Buyer?> FindByIdAsync(Guid id)
        {
            _buyers.TryGetValue(id, out Buyer? buyer);
            return Task.FromResult(buyer);
        }
    }
}
