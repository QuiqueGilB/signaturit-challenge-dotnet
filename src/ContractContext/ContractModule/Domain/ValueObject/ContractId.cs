using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.ValueObject;

public record ContractId(string Value) : Uuid(Value);