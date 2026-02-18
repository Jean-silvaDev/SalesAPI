using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext appContext) : base(appContext) { }
}
