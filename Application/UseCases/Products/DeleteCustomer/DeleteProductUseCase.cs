using Domain.Interfaces.Repositories;

namespace Application.UseCases.Products.DeleteCustomer;

public class DeleteProductUseCase
{
    public readonly IProductRepository _repository;

    public DeleteProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(id, cancellationToken);
        if (product == null)
            throw new Exception("Produto não encontrado");

        await _repository.DeleteAsync(id, cancellationToken);
        await _repository.CommitAsync(cancellationToken);
    }
}
