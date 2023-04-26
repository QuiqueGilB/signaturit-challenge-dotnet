using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.SharedModule.Domain.Model;

public abstract class AggregateRoot : Aggregate
{
    protected AggregateRoot(Uuid id) : base(id)
    {
    }
}
