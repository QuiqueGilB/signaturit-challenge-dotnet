using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Exception;

public class ContractAlreadyHasWinnerException : DomainException
{
    public ContractAlreadyHasWinnerException(string message) : base(message)
    {
    }
    
    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("CONTRACT_ALREADY_HAS_WINNER_ERROR");
    }

    public static ContractAlreadyHasWinnerException HasAlready(Uuid contractId)
    {
        return new ContractAlreadyHasWinnerException($"The contract {contractId} already has a winner");
    }
}
