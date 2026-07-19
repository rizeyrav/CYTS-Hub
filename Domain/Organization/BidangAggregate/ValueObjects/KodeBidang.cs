namespace Domain.Organization.UnitKerjaAggregate.ValueObjects;
using Domain.Common.Abstractions;
using Domain.Common.Guards;

public sealed class KodeBidang : ValueObject
{
    public string Value { get; }
    private KodeBidang(string value)
    {
        Value = value;
    }
    public static KodeBidang Create(string kode)
    {
        Guard.Againts.NullOrWhiteSpace(kode,nameof(kode));
        Guard.Againts.MaxLength(kode,10,nameof(kode));
        var kodeBidang = new KodeBidang(kode.Trim().ToUpperInvariant());
        return kodeBidang;
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    public override string ToString() => Value;
}