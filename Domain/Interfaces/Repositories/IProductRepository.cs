using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);
}
