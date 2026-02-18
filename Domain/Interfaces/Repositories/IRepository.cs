namespace Domain.Interfaces.Repositories;

public interface IRepository <T>
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> SaveAsync(T? entity, CancellationToken cancellationToken);
    Task<T?> UpdateAsync(Guid id, T? entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}
