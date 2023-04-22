using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.CqrsModule.Domain.Model;

public record Command
{
    public Uuid CommandId;
    
    protected Command(Uuid? commandId = null)
    {
        CommandId = commandId ?? Uuid.V4();
    }
}
