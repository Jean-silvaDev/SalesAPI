using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected AppDbContext appContext { get; set; }

    public Repository(AppDbContext appContext)
    {
        this.appContext = appContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await appContext.Set<T>().FindAsync(id, cancellationToken);

    public async Task<IReadOnlyList<T?>> GetAllAsync(Guid id, CancellationToken cancellationToken) => appContext.Set<T>().ToList();

    public async Task<T?> SaveAsync(T? entity, CancellationToken cancellationToken)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var result = appContext.Set<T>().Add(entity);
        return result.Entity;
    }

    public async Task<T?> UpdateAsync(Guid id, T? entity, CancellationToken cancellationToken)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var entityFound = await appContext.Set<T>().FindAsync(id, cancellationToken);

        if (entityFound is null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        var result = appContext.Set<T>().Update(entity);

        return result.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) => 
        appContext.Set<T>().Remove(await appContext.Set<T>().FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException($"Entity with id {id} not found."));

    public void CommitAsync(Guid id, CancellationToken cancellationToken) => appContext.SaveChangesAsync(cancellationToken);
}
