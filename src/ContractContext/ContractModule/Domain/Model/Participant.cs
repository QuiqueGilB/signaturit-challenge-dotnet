using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;
using app.SharedContext.SharedModule.Domain.Model;

namespace app.ContractContext.ContractModule.Domain.Model;

public class Participant : Aggregate<ParticipantId>
{
    public List<Signature> Signatures { get; private set; }
    public List<Signature> SignaturesToWin { get; private set; }
    public Score? Score { get; private set; }
    public bool HasUnknownSignature => Signatures.Exists(signature => Signature.Unknown.Equals(signature));
    
    public Participant(ParticipantId id, Signature[] signatures) : base(id)
    {
        Signatures = signatures.ToList();
        SignaturesToWin = new List<Signature>();
        Score = null;
    }

    public void Put(Score? score, List<Signature> signatureToWin, List<Signature> signatures)
    {
        DoUpdate(score, signatureToWin, signatures);
    }

    public void Patch(Score? score = null, List<Signature>? signaturesToWin = null, List<Signature>? signatures = null)
    {
        Put(
            score ?? Score,
            signaturesToWin ?? SignaturesToWin,
            signatures ?? Signatures
        );
    }

    private void DoUpdate(Score? score, List<Signature> signatureToWin, List<Signature> signatures)
    {
        Signatures = signatures;
        SignaturesToWin = signatureToWin;
        Score = score;
    }
}
