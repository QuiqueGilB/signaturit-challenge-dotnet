using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface ICommandHandler<T> where T: Command
{
    public Task Handle(T command);
}
