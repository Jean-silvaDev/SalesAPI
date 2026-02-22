using Application.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Customers.GetAllCustomers;

public class GetAllCustomersUseCase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCustomersUseCase(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerResponseDto>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<CustomerResponseDto>>(await _repository.GetAllAsync(cancellationToken));
    }
}