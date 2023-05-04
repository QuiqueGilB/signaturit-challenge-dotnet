using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Event;

public record ContractWonEvent(ContractId ContractId, Uuid WinnerParticipantId, int WinnerScore, DateTime UpdatedAt) : ContractEvent(ContractId)
{
    protected new static string Happened() => "won";
}
