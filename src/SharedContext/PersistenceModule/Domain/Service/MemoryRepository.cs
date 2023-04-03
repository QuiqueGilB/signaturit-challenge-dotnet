using app.SharedContext.PersistenceModule.Domain.Contract;
using app.SharedContext.SharedModule.Domain.Model;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.PersistenceModule.Domain.Service;

public class MemoryRepository<T> : IRepository<T> where T : AggregateRoot
{
    protected readonly Dictionary<string, T> Storage = new Dictionary<string, T>();

    public Task<T?> ById(Uuid id)
    {
        var key = id.ToString();
        Storage.TryGetValue(key, out var value);
        return Task.FromResult(value);
    }

    public Task Save(T entity)
    {
        Storage.Add(entity.Id.ToString(), entity);
        return Task.CompletedTask;
    }
}