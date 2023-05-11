using app.ContractContext.ContractModule.Domain.Service;
using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;
using Xunit;

namespace app.Tests.Unit.ContractContext.ContractModule.Domain.Service;

public class ResolveNeedSignatureToWinServiceTest
{
    private readonly ResolveNeedSignatureToWinService _needSignatureToWinService;

    public ResolveNeedSignatureToWinServiceTest()
    {
        _needSignatureToWinService = new ResolveNeedSignatureToWinService(new ResolveSignatureScoresService());
    }

    [Theory]
    [MemberData(nameof(StagesTestNeedToWin))]
    public void TestNeedToWin(IEnumerable<Signature> signatureToWinExpect, Score score, IEnumerable<Signature> signatures)
    {
        var signaturesToWin = _needSignatureToWinService.NeedToWin(score, signatures);
        Assert.Equal(signatureToWinExpect, signaturesToWin);
    }
    
    public static IEnumerable<object[]> StagesTestNeedToWin()
    {
        yield return new object[]{new []{Signature.King, Signature.Notary}, new Score(7), new []{Signature.Notary}}; // need many
        yield return new object[]{new[]{Signature.Notary}, new Score(5), new[]{Signature.King}}; // only need one
        yield return new object[]{Array.Empty<Signature>(), new Score(1), new[]{Signature.Notary}}; // is already winner
    }
}
