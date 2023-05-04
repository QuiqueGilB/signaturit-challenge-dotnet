using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.ValueObject;

public record ParticipantId(string Value) : Uuid(Value);