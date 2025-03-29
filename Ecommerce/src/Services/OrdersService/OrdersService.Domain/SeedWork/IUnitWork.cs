namespace Ecommerce.src.Services.OrdersService.OrdersService.Domain.SeedWork
{
    public interface IUnitWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }

}
