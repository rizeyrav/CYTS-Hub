namespace Domain.Common.Abstractions;

public interface IDomainEvent
{
    DateTimeOffset OccuredOn { get; }
}