using System.Collections.Immutable;
using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Service;

public class ResolveNeedSignatureToWinService
{
    private readonly ResolveSignatureScoresService _resolveSignatureScoresService;

    public ResolveNeedSignatureToWinService(ResolveSignatureScoresService resolveSignatureScoresService)
    {
        _resolveSignatureScoresService = resolveSignatureScoresService;
    }

    public Signature[] NeedToWin(Score maxScore, IEnumerable<Signature> signatures)
    {
        if (maxScore.Value < _resolveSignatureScoresService.Accumulate(signatures).Value)
        {
            return Array.Empty<Signature>();
        }

        var signaturesOrderered = signatures.OrderBy(signature => _resolveSignatureScoresService.Score(signature));

        var needToWin = new List<Signature>();
        while (true)
        {
            foreach (var signature in signaturesOrderered)
            {
                if (maxScore.Value < _resolveSignatureScoresService
                        .Accumulate(signatures.ToImmutableList().Concat(needToWin).Append(signature)).Value)
                {
                    return needToWin.Append(signature).ToArray();
                }
            }

            needToWin.Append(signaturesOrderered.Last());
        }
    }
}