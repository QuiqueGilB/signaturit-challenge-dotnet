using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.CqrsModule.Domain.Model;

public record Query
{
    public readonly Uuid QueryId;
    
    Query(Uuid? queryId = null)
    {
        QueryId = queryId ?? Uuid.V4();
    }
}
