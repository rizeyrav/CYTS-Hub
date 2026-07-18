namespace Domain.Common.Abstractions;

public interface IHasConcurrencyToken
{
    byte[]RowVersion { get; }
}