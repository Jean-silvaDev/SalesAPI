using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext appContext;

    public Repository(AppDbContext appContext)
    {
        this.appContext = appContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await appContext.Set<T>()
            .FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await appContext.Set<T>()
            .ToListAsync(cancellationToken) ?? [];
    }

    public async Task<T?> SaveAsync(T? entity, CancellationToken cancellationToken)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        var result = await appContext.Set<T>().AddAsync(entity, cancellationToken);
        return result.Entity;
    }

    public async Task<T?> UpdateAsync(Guid id, T? entity, CancellationToken cancellationToken)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        var entityFound = await appContext.Set<T>()
            .FindAsync(new object[] { id }, cancellationToken);

        if (entityFound is null)
            throw new KeyNotFoundException($"Entity with id {id} not found.");

        appContext.Entry(entityFound).CurrentValues.SetValues(entity);
        return entityFound;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await appContext.Set<T>()
            .FindAsync(new object[] { id }, cancellationToken)
            ?? throw new KeyNotFoundException($"Entity with id {id} not found.");

        appContext.Set<T>().Remove(entity);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await appContext.SaveChangesAsync(cancellationToken);
    }
}