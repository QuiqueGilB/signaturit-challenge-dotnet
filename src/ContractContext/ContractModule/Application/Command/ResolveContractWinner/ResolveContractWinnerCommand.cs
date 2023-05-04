using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Application.Command.ResolveContractWinner;

public record ResolveContractWinnerCommand(Uuid CommandId, ContractId ContractId) :
    app.SharedContext.CqrsModule.Domain.Model.Command(CommandId)
{
}