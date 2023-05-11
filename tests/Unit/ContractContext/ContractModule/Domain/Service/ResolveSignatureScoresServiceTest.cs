using app.ContractContext.ContractModule.Domain.Service;
using app.ContractContext.ContractModule.Domain.ValueObject;
using app.ContractContext.SharedModule.Domain.ValueObject;

namespace app.Tests.Unit.ContractContext.ContractModule.Domain.Service;

public class ResolveSignatureScoresServiceTest
{
    private readonly ResolveSignatureScoresService _resolveSignatureScoresService;

    public ResolveSignatureScoresServiceTest()
    {
        _resolveSignatureScoresService = new ResolveSignatureScoresService();
    }


    [Theory]
    [MemberData(nameof(StagesTestAccumulateScore))]
    public void TestAccumulateScore(Score score, IEnumerable<Signature> signatures)
    {
        Assert.Equal(score, _resolveSignatureScoresService.Accumulate(signatures));
    }

    public static IEnumerable<object[]> StagesTestAccumulateScore()
    {
        yield return new object[] { new Score(5), new[] { Signature.King } }; //one king'
        yield return new object[] { new Score(2), new[] { Signature.Notary } }; //one notary'
        yield return new object[] { new Score(1), new[] { Signature.Validator } }; //one validator'
        yield return new object[] { new Score(0), new[] { Signature.Unknown } }; //one unknown'
        yield return new object[] { new Score(7), new[] { Signature.King, Signature.Notary } }; //king-notary'
        yield return new object[]
            { new Score(7), new[] { Signature.King, Signature.Notary, Signature.Validator } }; //king-notary-validator
        yield return new object[]
            { new Score(5), new[] { Signature.King, Signature.Unknown, Signature.Validator } }; //king-unknown-validator
        yield return new object[] { new Score(3), new[] { Signature.Validator, Signature.Notary } }; //validator-notary'
    }
}
