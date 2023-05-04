using System.Text.Json;
using app.SharedContext.SerializerModule.Domain.Contract;
using app.SharedContext.SerializerModule.Domain.Enum;

namespace app.SharedContext.SerializerModule.Infrastructure.Serializer.Net;

public class NetSerializer : ISerializer
{
    public string Serialize(dynamic data, SerializerFormat outputFormat)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true,
            AllowTrailingCommas = true,
            IgnoreReadOnlyProperties = false,
            IgnoreReadOnlyFields = false,
        };

        return outputFormat switch
        {
            SerializerFormat.Json => JsonSerializer.Serialize(data, options),
            _ => throw new ArgumentException("")
        };
    }
}