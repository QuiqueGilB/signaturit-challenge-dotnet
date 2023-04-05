using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Exception;

public class ContractNotFoundException : DomainException
{
    public ContractNotFoundException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("CONTRACT_NOT_FOUND");
    }

    public static ContractNotFoundException ById(Uuid id)
    {
        return new ContractNotFoundException($"Contract with id {id.Value} not found");
    }
}
