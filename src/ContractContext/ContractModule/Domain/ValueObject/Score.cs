using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.ValueObject;

public record Score(int Value) : ValueObject<int>(Value);