using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.DeleteCustomer;

public class GetCustomerByIdUseCase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCustomerByIdUseCase(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerResponseDto?> ExecuteAsync(
        GetCustomerByIdCommand command,
        CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (customer == null)
            return null;

        return _mapper.Map<CustomerResponseDto>(customer);
    }
}