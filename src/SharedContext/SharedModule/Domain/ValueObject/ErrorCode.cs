namespace app.SharedContext.SharedModule.Domain.ValueObject;

public record ErrorCode(string Value) : StringValueObject(Value)
{
}