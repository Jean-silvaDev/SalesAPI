using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext appContext) : base(appContext) { }

    public async Task<IEnumerable<Order>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        => await appContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Products)
            .ToListAsync(cancellationToken);

    public async Task<Order?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default) 
        => await appContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
}
