namespace Domain.Organization.JabatanAggregate.ValueObjects;
using Domain.Common.Abstractions;
using Domain.Common.Guards;

public sealed class KodeJabatan : ValueObject
{
    public string Value { get; }
    private KodeJabatan(string value)
    {
        Value = value;
    }
    public static KodeJabatan Create(string kode)
    {
        Guard.Againts.NullOrWhiteSpace(kode,nameof(kode));
        Guard.Againts.MaxLength(kode,25, nameof(kode));
        var normalized = kode.Trim().ToUpperInvariant();
        return new KodeJabatan(normalized);
    }
    protected override IEnumerable<Object?> GetEqualityComponents()
    {
        yield return Value;
    }
    public override string ToString()=>Value;
}