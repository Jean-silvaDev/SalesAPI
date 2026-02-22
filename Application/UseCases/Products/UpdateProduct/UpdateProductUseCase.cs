using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Products.UpdateProduct;

public class UpdateProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductUseCase(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductResponseDto?> ExecuteAsync(Guid id, UpdateProductCommand command, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(id, cancellationToken);
        if (product is null)
            throw new Exception("Product not found!");

        product.Name = command.Name;
        product.Price = command.Price;

        var resultProduct = await _repository.UpdateAsync(id, product, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        if (resultProduct is null)
            return null;

        return _mapper.Map<ProductResponseDto>(resultProduct);
    }
}
