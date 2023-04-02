namespace app.SharedContext.CqrsModule.Domain.Model;

public struct QueryMetadata
{
    public readonly int Results, Total, Limit, Offset;
    
    QueryMetadata(int results, int total, int limit, int offset)
    {
        Results = results;
        Total = total;
        Limit = limit;
        Offset = offset;
    }
}
