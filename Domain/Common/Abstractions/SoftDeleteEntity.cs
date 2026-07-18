namespace Domain.Common.Abstractions;

public abstract class SoftDeleteEntity : AggregateRoot
{
    public bool IsDeleted { get; protected set; }
    public DateTimeOffset? DeletedAt { get; protected set; }
    public void Delete()
    {
        if(IsDeleted)return;
        IsDeleted = true;
        DeletedAt = DateTimeOffset.UtcNow;
        MarkUpdated();
        // AddDomainEvents(new SoftDeleteEntity(Id,GetType().Name));
    }
    public void Restore()
    {
        if(!IsDeleted) return;
        IsDeleted = false;
        DeletedAt = null;
        MarkUpdated();
        // AddDomainEvents(new SoftDeleteEntity(Id,GetType().Name));
    }
}