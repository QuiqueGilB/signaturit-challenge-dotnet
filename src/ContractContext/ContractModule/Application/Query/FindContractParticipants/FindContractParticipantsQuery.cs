using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.ContractModule.Domain.View;
using app.SharedContext.CqrsModule.Domain.Model;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Application.Query.FindContractParticipants;

public record FindContractParticipantsQuery(Uuid QueryId, ContractId ContractId)
    : Query<IEnumerable<ParticipantView>>(QueryId);