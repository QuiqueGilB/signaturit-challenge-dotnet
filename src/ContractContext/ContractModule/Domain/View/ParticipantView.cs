using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.View;

public sealed record ParticipantView(ParticipantId ParticipantId, IEnumerable<Signature> Signatures) : SharedContext.SharedModule.Domain.Model.View;
