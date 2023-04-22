using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface IQueryBus
{
    public Task<QueryResponse<T>> Ask<T>(Query<T> query);
}