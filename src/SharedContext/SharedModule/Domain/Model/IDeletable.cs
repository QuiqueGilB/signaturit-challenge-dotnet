namespace app.SharedContext.SharedModule.Domain.Model;

public interface IDeletable
{
    public DateTime? DeletedAt { get; protected set; }

    public void Delete() => DeletedAt = DateTime.Now;
    public bool IsDeleted() => DeletedAt is not null && DeletedAt < DateTime.Now;
}