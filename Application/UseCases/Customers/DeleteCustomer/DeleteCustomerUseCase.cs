using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.DeleteCustomer;

public class DeleteCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {

        await _repository.DeleteAsync(command.Id, cancellationToken);
        await _repository.CommitAsync(cancellationToken);
    }
}