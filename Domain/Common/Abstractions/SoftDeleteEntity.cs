namespace Domain.Common.Abstractions;

public abstract class SoftDeleteEntity : BaseEntity
{
    public bool IsDeleted { get; protected set; }
    public void Delete()
    {
        IsDeleted = true;
        MarkUpdated();
    }
    public void Restore()
    {
        IsDeleted = false;
        MarkUpdated();
        // AddDomainEvents(new SoftDeleteEntity(Id,GetType().Name));
    }
}