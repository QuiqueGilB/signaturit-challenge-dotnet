using app.ContractContext.ContractModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Event;

public record ContractCreatedEvent(ContractId ContractId, DateTime UpdatedAt, DateTime CreatedAt) : ContractEvent(ContractId)
{
    protected new static string Happened() => "created";
}
