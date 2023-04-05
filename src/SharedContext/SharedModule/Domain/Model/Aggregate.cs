using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.SharedModule.Domain.Model;

public abstract class Aggregate
{
    public readonly Uuid Id;
    public readonly DateTime CreatedAt;
    public DateTime UpdatedAt { get; protected set; }

    protected Aggregate(Uuid id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}