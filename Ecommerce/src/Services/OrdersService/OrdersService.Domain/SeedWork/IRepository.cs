using Ecommerce.src.Services.UsersService.UsersService.Domain.SeedWork;

namespace Ecommerce.src.Services.OrdersService.OrdersService.Domain.SeedWork
{

    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitWork UnitWork { get; }
    }

}
