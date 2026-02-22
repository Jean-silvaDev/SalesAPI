using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Products.GetAllProducts;

public class GetAllProductsUseCase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductsUseCase(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponseDto>> ExecuteAsync(CancellationToken cancellationToken = default)
        => _mapper.Map<IEnumerable<ProductResponseDto>>(await _repository.GetAllAsync(cancellationToken));
}
