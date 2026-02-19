using Application.UseCases.Customers.CreateCustomer;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.DeleteCustomer;

public class UpdateCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(Guid id, UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Email = command.Email,
            CPF = command.CPF,
            PhoneNumber = command.PhoneNumber
        };

        await _repository.UpdateAsync(id, customer, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        return customer.Id;
    }
}