using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.SharedModule.Domain.Model;

public abstract class Aggregate<T> where T : Uuid
{
    public readonly T Id;
    public readonly DateTime CreatedAt;
    public DateTime UpdatedAt { get; protected set; }

    protected Aggregate(T id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}