using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appContext) : base(appContext) { }

    public async Task<IEnumerable<Product>> GetByIdsAsync(
        List<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        if (ids == null || !ids.Any())
            return Enumerable.Empty<Product>();

        return await appContext.Products
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }
}
