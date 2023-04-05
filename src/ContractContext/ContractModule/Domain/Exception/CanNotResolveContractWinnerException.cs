using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Exception;

public class CanNotResolveContractWinnerException : DomainException
{
    public CanNotResolveContractWinnerException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("CAN_NOT_RESOLVE_CONTRACT_WINNER_ERROR");
    }

    public static CanNotResolveContractWinnerException Zero(Uuid contractId)
    {
        return new CanNotResolveContractWinnerException($"The contract {contractId} has zero winners");
    }

    public static CanNotResolveContractWinnerException Many(Uuid contractId)
    {
        return new CanNotResolveContractWinnerException(
            $"The contract {contractId} has many winners and can not resolve"
        );
    }
}
