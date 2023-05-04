using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.SharedModule.Domain.Data;

public struct ParticipantData
{
    public readonly ParticipantId ParticipantId;
    public readonly Signature[] Signatures;
    public readonly Signature[] NeedToWin;
    
    public ParticipantData(ParticipantId participantId, Signature[] signatures, Signature[] needToWin)
    {
        ParticipantId = participantId;
        Signatures = signatures;
        NeedToWin = needToWin;
    }
}
