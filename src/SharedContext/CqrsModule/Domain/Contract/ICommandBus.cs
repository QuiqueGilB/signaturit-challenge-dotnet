using app.SharedContext.CqrsModule.Domain.Model;

namespace app.SharedContext.CqrsModule.Domain.Contract;

public interface ICommandBus
{
    public Task Handle(Command command);
}
