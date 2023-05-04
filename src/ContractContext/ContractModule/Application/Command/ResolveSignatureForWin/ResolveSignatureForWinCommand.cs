using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Application.Command.ResolveSignatureForWin;

public record ResolveSignatureForWinCommand(Uuid CommandId, ContractId ContractId) : 
    SharedContext.CqrsModule.Domain.Model.Command(CommandId);
