using app.ContractContext.ContractModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.View;

public record ContractView : SharedContext.SharedModule.Domain.Model.View
{
     public readonly ContractId ContractId;
     public readonly ParticipantView? Winner;

     public ContractView(Model.Contract contract)
     {
         ContractId = contract.Id;
         Winner = contract.Winner == null 
             ? null 
             : new ParticipantView(contract.Winner.Id, contract.Winner.Signatures);
     }
}