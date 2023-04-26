using System.Text.RegularExpressions;
using app.SharedContext.SharedModule.Domain.Exception;
using static System.Guid;

namespace app.SharedContext.SharedModule.Domain.ValueObject;

public record Uuid(string Value) : ValueObject<string>(Value)
{
    private const string UuidRegex = "/^[0-9A-F]{8}-[0-9A-F]{4}-4[0-9A-F]{3}-[89AB][0-9A-F]{3}-[0-9A-F]{12}$/i";

    public override void Validate()
    {
        if (!Regex.IsMatch(UuidRegex, Value))
        {
            InvalidUuidException.ByValue(Value);
        }
    }

    public static Uuid V4()
    {
        return new Uuid(NewGuid().ToString());
    }
}