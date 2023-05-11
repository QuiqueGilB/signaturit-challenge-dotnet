using app.SharedContext.SharedModule.Domain.Exception;
using app.SharedContext.SharedModule.Domain.ValueObject;
using Xunit;

namespace app.Tests.Unit.SharedContext.SharedModule.Domain.ValueObject;

public class UuidTest
{
    [Theory]
    [InlineData("30a34c36-1078-4224-a2d6-c11f75b64f6a", true)]
    [InlineData("a fake uuid", false)]
    public void TestValidUuid(string uuid, bool isValid)
    {
        var exception = Record.Exception(() => new Uuid(uuid));

        if (isValid) Assert.Null(exception);
        if (!isValid) Assert.IsType<InvalidUuidException>(exception);
    }

    [Theory]
    [InlineData("30a34c36-1078-4224-a2d6-c11f75b64f6a")]
    public void TestToString(string uuid)
    {
        Assert.Equal(uuid, (new Uuid(uuid)).ToString());
    }
}
