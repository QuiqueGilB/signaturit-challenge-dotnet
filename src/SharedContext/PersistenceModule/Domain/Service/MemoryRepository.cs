using app.SharedContext.PersistenceModule.Domain.Contract;
using app.SharedContext.SharedModule.Domain.Model;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.PersistenceModule.Domain.Service;

public class MemoryRepository<T, TK> : IRepository<T, TK> 
    where T : AggregateRoot<TK>
    where TK : Uuid
{
    protected readonly Dictionary<string, T> Storage = new();

    public Task<T?> ById(TK id)
    {
        var key = id.ToString();
        Storage.TryGetValue(key, out var value);
        return Task.FromResult(value);
    }

    public Task Save(T entity)
    {
        Storage.TryAdd(entity.Id.ToString(), entity);
        return Task.CompletedTask;
    }
}