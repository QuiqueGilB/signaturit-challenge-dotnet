using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Exception;

public class ContractHasNotWinnerException : DomainException
{
    public ContractHasNotWinnerException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("CONTRACT_WINNER_ERROR");
    }

    public static ContractHasNotWinnerException Unresolved(Uuid contractId)
    {
        return new ContractHasNotWinnerException($"The contract {contractId} has not winner");
    }
}
