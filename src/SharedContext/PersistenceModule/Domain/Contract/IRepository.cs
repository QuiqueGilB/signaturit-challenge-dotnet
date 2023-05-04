using app.SharedContext.SharedModule.Domain.Model;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.PersistenceModule.Domain.Contract;

public interface IRepository<T, in TK>
    where T : AggregateRoot<TK>
    where TK : Uuid
{
    public Task<T?> ById(TK id);
    public Task Save(T entity);
}