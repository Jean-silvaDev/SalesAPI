using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Products.CreateProduct
{
    public class CreateProductUseCase
    {
        private readonly IProductRepository _repository;

        public CreateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> ExecuteAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
            };

            await _repository.SaveAsync(product, cancellationToken);
            await _repository.CommitAsync(cancellationToken);

            return product.Id;
        }
    }
}
