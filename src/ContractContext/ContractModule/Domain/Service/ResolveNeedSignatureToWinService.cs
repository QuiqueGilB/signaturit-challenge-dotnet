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
        signatures = signatures.ToImmutableList();

        if (maxScore.Value < _resolveSignatureScoresService.Accumulate(signatures).Value)
        {
            return Array.Empty<Signature>();
        }

        var signaturesOrderered = Enum.GetValues<Signature>()
            .OrderBy(signature => _resolveSignatureScoresService.Score(signature));

        var needToWin = new List<Signature>();
        while (true)
        {
            foreach (var signature in signaturesOrderered)
            {
                var suggestToWin = needToWin.ToImmutableList().Add(signature);
                if (maxScore.Value < _resolveSignatureScoresService
                        .Accumulate(signatures.Concat(suggestToWin)).Value)
                {
                    return suggestToWin.ToArray();
                }
            }

            needToWin.Add(signaturesOrderered.Last());
        }
    }
}