using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
    Task<Order?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
}