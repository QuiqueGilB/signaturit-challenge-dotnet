namespace app.SharedContext.SharedModule.Domain.ValueObject;

public record ErrorCode(string Value) : ValueObject<string>(Value)
{
}
