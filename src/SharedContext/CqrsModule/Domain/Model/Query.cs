using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.CqrsModule.Domain.Model;

public record Query<T>
{
    public readonly Uuid QueryId;

    protected Query(Uuid? queryId = null)
    {
        QueryId = queryId ?? Uuid.V4();
    }
}

public record Query : Query<object>;