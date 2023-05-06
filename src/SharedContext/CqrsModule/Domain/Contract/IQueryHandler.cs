using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface IQueryHandler<in T, TK> : IQueryHandler
    where T : Query<TK>
{
    async Task<QueryResponse<O>> IQueryHandler.Ask<O>(Query<O> query)
    {
        var queryResponse = await Ask((query as T)!);
        return (QueryResponse<O>)Convert.ChangeType(queryResponse, typeof(QueryResponse<O>));
    }

    public Task<QueryResponse<TK>> Ask(T query);
}

public interface IQueryHandler
{
    public Task<QueryResponse<T>> Ask<T>(Query<T> query);
}