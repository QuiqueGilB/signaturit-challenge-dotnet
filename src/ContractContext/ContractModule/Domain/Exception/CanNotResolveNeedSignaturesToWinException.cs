using app.ContractContext.SharedModule.Domain.ValueObject;
using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Exception;

public class CanNotResolveNeedSignaturesToWinException : DomainException
{
    public CanNotResolveNeedSignaturesToWinException(string message) : base(message)
    {
    }

    public override ErrorCode ErrorCode()
    {
        return new ErrorCode("IMPOSSIBLE_WIN");
    }

    public static CanNotResolveNeedSignaturesToWinException OnlyOnceSignature(
        int score,
        IEnumerable<Signature> signatures
    )
    {
        return new CanNotResolveNeedSignaturesToWinException(
            $"It is impossible to win with only one signature to {score} score with the signatures [{String.Join(", ", signatures)}]"
        );
    }
}
