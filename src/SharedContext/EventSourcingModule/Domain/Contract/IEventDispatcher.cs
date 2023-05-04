using app.SharedContext.EventSourcingModule.Domain.Event;

namespace app.SharedContext.EventSourcingModule.Domain.Contract;

public interface IEventDispatcher
{
    public Task Dispatch(DomainEvent domainEvent);
}
