using app.SharedContext.SharedModule.Domain.Contract;

namespace app.SharedContext.SharedModule.Domain.ValueObject;

public abstract record ValueObject: IValidatable
{
    protected ValueObject()
    {
        Validate();
    }

    public virtual void Validate()
    {
        
    }
}