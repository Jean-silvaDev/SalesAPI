using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.GetAllCustomers;

public class GetAllCustomersUseCase
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Domain.Entities.Customer>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}