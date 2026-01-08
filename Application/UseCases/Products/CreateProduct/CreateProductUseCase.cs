using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.UseCases.Products.CreateProduct;

public class CreateProductUseCase
{
    private readonly IProductRepository _repo;

    public CreateProductUseCase(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.name,
            Description = dto.description,
            Price = dto.price
        };
        await _repo.AddAsync(product);
    }
}
