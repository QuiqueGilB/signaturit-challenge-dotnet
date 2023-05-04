using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.EventSourcingModule.Domain.Exception;

public class InvalidEventNameException : DomainException
{
    private InvalidEventNameException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("INVALID_EVENT_NAME");
    }

    public static InvalidEventNameException ByContext(string context)
    {
        return new InvalidEventNameException($"The context ({context}) of event name required end with 'Context'");
    }

    public static InvalidEventNameException ByModule(string module)
    {
        return new InvalidEventNameException($"The module ({module}) of event name required end with 'Module'");
    }

    public static InvalidEventNameException ByVersion(string version)
    {
        return new InvalidEventNameException($"The version ({version}) of event name required format \\^v\\d+\\$\\");
    }
}
