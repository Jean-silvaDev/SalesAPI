using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.DeleteCustomer;

public class GetCustomerByIdUseCase
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> ExecuteAsync(GetCustomerByIdCommand command, CancellationToken cancellationToken) 
        => await _repository.GetByIdAsync(command.Id, cancellationToken);
}