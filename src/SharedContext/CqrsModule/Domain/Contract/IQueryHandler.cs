using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface IQueryHandler<T, K> where T: Query
{
    public Task<QueryResponse<K>> Ask(T query);
}
