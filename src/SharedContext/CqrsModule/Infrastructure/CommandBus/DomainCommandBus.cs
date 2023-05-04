using app.SharedContext.CqrsModule.Domain.Contract;
using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Infrastructure.CommandBus;

public class DomainCommandBus : ICommandBus
{
    private readonly Dictionary<string, ICommandHandler> _commandHandlers;

    public DomainCommandBus(IEnumerable<ICommandHandler> commandHandlers)
    {
        _commandHandlers = commandHandlers.ToDictionary(handler =>
        {
            var commandType = handler.GetType().GetInterfaces().First().GetGenericArguments().First();
            return commandType.ToString();
        });
    }

    public async Task Handle(Command command)
    {
        var handler = _commandHandlers[command.GetType().ToString()];
        await handler.Handle(command);
    }
}