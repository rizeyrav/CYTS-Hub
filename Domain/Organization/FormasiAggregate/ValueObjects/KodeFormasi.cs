namespace Domain.Organization.FormasiAggregate.ValueObjects;
using Domain.Common.Abstractions;
using Domain.Common.Guards;

public sealed class KodeFormasi : ValueObject
{
    public string Value { get; }
    private KodeFormasi(string value)
    {
        Value = value;
    }
    public static KodeFormasi Create(string kode)
    {
        Guard.Againts.NullOrWhiteSpace(kode, nameof(kode));
        Guard.Againts.MaxLength(kode,10,nameof(kode));
        return new KodeFormasi(kode.Trim().ToUpperInvariant());
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    public override string ToString()=> Value;
}