using Ecommerce.src.Services.OrdersService.OrdersService.Domain.SeedWork;
using Ecommerce.src.Services.UsersService.UsersService.Domain.AggregatesModel.BuyerAggregate;

namespace Ecommerce.src.Services.OrdersService.OrdersService.Domain.AggregatesModel.BuyerAggregate
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        Buyer Add(Buyer buyer);
        Buyer Update(Buyer buyer);
        Task<Buyer> FindAsync(string buyerIdentityGuid);
        Task<Buyer> FindByIdAsync(Guid id); 
    }
}
