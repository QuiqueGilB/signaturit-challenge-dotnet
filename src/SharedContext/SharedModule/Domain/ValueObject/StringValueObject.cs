namespace app.SharedContext.SharedModule.Domain.ValueObject;

public abstract record StringValueObject(string Value) : ValueObject
{
    public override string ToString()
    {
        return Value;
    }
}