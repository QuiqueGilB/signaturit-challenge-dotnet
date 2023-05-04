using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.SharedContext.EventSourcingModule.Domain.Event;

public abstract record DomainEvent(string Version = "v1")
{
    public Uuid EventId { get; } = Uuid.V4();
    public DateTime OccurredOn { get; } = DateTime.Now;
    
    public static EventName EventName => new EventName(Context, Module, Resource, Happened);
    protected static string Context => throw new NotImplementedException();
    protected static string Module => throw new NotImplementedException();
    protected static string Resource => throw new NotImplementedException();
    protected static string Happened => throw new NotImplementedException();
}