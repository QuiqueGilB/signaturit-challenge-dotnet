using app.SharedContext.SharedModule.Domain.Contract;

namespace app.SharedContext.SharedModule.Domain.ValueObject;

public abstract record ValueObject: IValidatable
{
    protected ValueObject()
    {
        Validate();
    }

    public virtual void Validate()
    {
        
    }
}

public abstract record ValueObject<T>(T Value) : ValueObject
{
    public sealed override string ToString()
    {
        return Value?.ToString() ?? "";
    }
}