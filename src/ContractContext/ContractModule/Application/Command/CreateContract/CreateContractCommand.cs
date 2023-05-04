using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.Data;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Application.Command.CreateContract;

public sealed record CreateContractCommand(Uuid CommandId, ContractId ContractId, ParticipantData[] Participants) :
    app.SharedContext.CqrsModule.Domain.Model.Command(CommandId)
{
}