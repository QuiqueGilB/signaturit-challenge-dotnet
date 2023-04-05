using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Exception;

public class MinContractParticipantsException : DomainException
{
    public MinContractParticipantsException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("MIN_CONTRACT_PARTICIPANTS_ERROR");
    }

    public static MinContractParticipantsException ById(Uuid contractId, int min)
    {
        return new MinContractParticipantsException($"Contract {contractId} required minimum {min} participants");
    }
}
