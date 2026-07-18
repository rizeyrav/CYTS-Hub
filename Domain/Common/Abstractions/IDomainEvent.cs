namespace Domain.Common.Abstractions;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}