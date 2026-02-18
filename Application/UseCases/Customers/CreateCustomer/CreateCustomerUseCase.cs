using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.CreateCustomer;

public class CreateCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Email = command.Email,
            CPF = command.CPF,
            PhoneNumber = command.PhoneNumber
        };

        await _repository.SaveAsync(customer, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        return customer.Id;
    }
}