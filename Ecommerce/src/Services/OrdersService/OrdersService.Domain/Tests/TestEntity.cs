using Ecommerce.src.Services.OrdersService.OrdersService.Domain.SeedWork;
using MediatR;
using Xunit;

namespace Ecommerce.src.Services.OrdersService.Tests
{
    public class TestEntityTests
    {
        [Fact]
        public void Constructor_SetsId()
        {
            var newId = Guid.NewGuid();
            var entity = new TestEntity(newId);
            Assert.Equal(newId, entity.Id);
        }

        [Fact]
        public void AddDomainEvent_AddsEventToDomainEvents()
        {
            var entity = new TestEntity(Guid.NewGuid());
            var domainEvent = new DomainEventTest();
            entity.AddDomainEvent(domainEvent);
            Assert.Contains(domainEvent, entity.DomainEvents);
        }
    }

    public class TestEntity : Entity
    {
        public TestEntity(Guid id)
        {
            Id = id;
        }
    }
    public class DomainEventTest : INotification { }
}
