using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.SharedModule.Domain.Exception;

public abstract class DomainException : System.Exception
{
    protected DomainException(string message) : base(message)
    {
    }

    public abstract ErrorCode ErrorCode();
}