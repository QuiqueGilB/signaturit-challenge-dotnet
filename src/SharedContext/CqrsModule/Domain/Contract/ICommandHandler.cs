using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface ICommandHandler<in T> : ICommandHandler where T : Command
{
    Task ICommandHandler.Handle(Command command)
    {
        return Handle((T)command);
    }

    public Task Handle(T command);
}

public interface ICommandHandler
{
    public Task Handle(Command command);
}