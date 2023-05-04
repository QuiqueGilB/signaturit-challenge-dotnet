using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.SharedModule.Domain.Model;

public abstract class AggregateRoot<T> : Aggregate<T> where T : Uuid
{
    protected AggregateRoot(T id) : base(id)
    {
    }
}
