using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.SharedModule.Domain.Exception;

public class InvalidUuidException : DomainException
{
    public InvalidUuidException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("INVALID_UUID");
    }

    public static InvalidUuidException ByValue(string value)
    {
        return new InvalidUuidException($"The value {value} is a uuid format invalid");
    }
}