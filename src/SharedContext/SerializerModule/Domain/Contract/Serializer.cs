using app.SharedContext.SerializerModule.Domain.Enum;

namespace app.SharedContext.SerializerModule.Domain.Contract;

public interface ISerializer
{
    public string Serialize(dynamic data, SerializerFormat outputFormat);
}