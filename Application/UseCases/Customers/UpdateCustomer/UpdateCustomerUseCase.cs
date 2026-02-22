using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.DeleteCustomer;

public class UpdateCustomerUseCase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCustomerUseCase(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerResponseDto?> ExecuteAsync(Guid id, UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Email = command.Email,
            CPF = command.CPF,
            PhoneNumber = command.PhoneNumber
        };

        var resultCustomer = await _repository.UpdateAsync(id, customer, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        if (resultCustomer == null)
            return null;

        return _mapper.Map<CustomerResponseDto>(resultCustomer);
    }
}