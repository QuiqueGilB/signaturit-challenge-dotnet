
using app.SharedContext.EventSourcingModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.EventSourcingModule.Domain.Event;

public record EventName : ValueObject
{
    private readonly string Context;
    private readonly string Module;
    private readonly string Resource;
    private readonly string Happened;
    
    public string Fqn => $"Signaturit.LobbyWarsChallenge.{Context}.{Module}.{Resource}.{Happened}";

    public EventName(string context, string module, string resource, string happened) : base()
    {
        Context = context;
        Module = module;
        Resource = resource;
        Happened = happened;
    }

    public override void Validate()
    {
        if(!Context.EndsWith("Context")) throw InvalidEventNameException.ByContext(Context);;
        if(!Module.EndsWith("Module")) throw InvalidEventNameException.ByModule(Module);
    }

    public override string ToString()
    {
        return Fqn;
    }
}
