using app.ContractContext.ContractModule.Application.Query.FindContract;
using app.SharedContext.CqrsModule.Domain.Contract;
using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Infrastructure.QueryBus;

public class DomainQueryBus : IQueryBus
{
    private readonly Dictionary<string, IQueryHandler> _queryHandlers;

    public DomainQueryBus(IEnumerable<IQueryHandler> queryHandlers)
    {
        _queryHandlers = queryHandlers.ToDictionary(handler =>
        {
            var queryType = handler.GetType().GetInterfaces().First().GetGenericArguments().First();
            // var queryType2 = handler.GetType().GetMethod("Ask").GetParameters().First().GetType();
            return queryType.ToString();
        });
        
        Console.WriteLine(_queryHandlers.Count());
    }

    public async Task<QueryResponse<T>> Ask<T>(Query<T> query)
    {
        Console.WriteLine("jejejejejjeje");
        var handler = _queryHandlers[query.GetType().ToString()];
        Console.WriteLine("wiiiiiiiiiiiiiii");
        return await handler.Ask(query);
    }
}