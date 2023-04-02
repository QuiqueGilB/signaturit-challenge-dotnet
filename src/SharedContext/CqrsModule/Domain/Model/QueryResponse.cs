namespace app.SharedContext.CqrsModule.Domain.Model;

public struct QueryResponse<T>
{
    public readonly T Data;
    public readonly QueryMetadata Metadata;
    
    QueryResponse(T data, QueryMetadata metadata)
    {
        Data = data;
        Metadata = metadata;
    }
}
