using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.EventSourcingModule.Domain.Event;

namespace app.ContractContext.ContractModule.Domain.Event;

public abstract record ContractEvent(ContractId ContractId) : DomainEvent
{
    protected new static string Context => "contractContext";
    protected new static string Module => "contractModule";
    protected new static string Resource => "contract";
}
