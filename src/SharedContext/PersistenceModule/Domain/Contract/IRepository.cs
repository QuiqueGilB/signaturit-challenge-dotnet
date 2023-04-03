using app.SharedContext.SharedModule.Domain.Model;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.PersistenceModule.Domain.Contract;

public interface IRepository<T> where T : AggregateRoot
{
    public Task<T?> ById(Uuid id);
    public Task Save(T entity);
}