using app.ContractContext.ContractModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Event;

public record ContractUpdatedEvent(ContractId ContractId, DateTime UpdatedAt) : ContractEvent(ContractId)
{
    protected new static string Happened() => "updated";
}
