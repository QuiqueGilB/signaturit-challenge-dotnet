using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Service;

public class ResolveSignatureScoresService
{
    public Score Accumulate(IEnumerable<Signature> signatures)
    {
        var hasKing = signatures.Contains(Signature.King);
        return new Score(signatures
            .Select(signature => hasKing && Signature.Validator.Equals(signature) ? 0 : Score(signature))
            .Sum());
    }


    public int Score(Signature signature)
    {
        return signature switch
        {
            Signature.King => 5,
            Signature.Notary => 2,
            Signature.Validator => 1,
            Signature.Unknown => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(signature), signature, null)
        };
    }
}