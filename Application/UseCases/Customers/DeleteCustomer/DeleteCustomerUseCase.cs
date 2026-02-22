using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.DeleteCustomer;

public class DeleteCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(id, cancellationToken);
        if (customer is null)
            throw new ArgumentNullException("Customer not found!");
        await _repository.DeleteAsync(id, cancellationToken);
        await _repository.CommitAsync(cancellationToken);
    }
}