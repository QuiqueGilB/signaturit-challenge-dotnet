using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface ICommandHandler<in T> where T: Command
{
    public Task Handle(T command);
}

public interface ICommandHandler: ICommandHandler<Command>
{
}
