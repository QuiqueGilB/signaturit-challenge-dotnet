using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface IQueryHandler<in T, TK> where T: Query<TK>
{
    public Task<QueryResponse<TK>> Ask(T query);
}

public interface IQueryHandler: IQueryHandler<
    Query<QueryResponse<object>>,
    QueryResponse<object>
    >
{
}
