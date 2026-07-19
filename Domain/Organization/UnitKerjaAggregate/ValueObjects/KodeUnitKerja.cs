using Domain.Common.Abstractions;
using Domain.Common.Exceptions;
using Domain.Common.Guards;
using Domain.Organization.Exceptions;
namespace Domain.Organization.UnitKerjaAggregate.ValueObjects;
public sealed class KodeUnitKerja : ValueObject
{
    private const int MaxLength = 80;
    public string Value { get; }
    private KodeUnitKerja(string value)
    {
        Value = value;
    }
    public static KodeUnitKerja Create(string kode)
    {
        Guard.Againts.NullOrWhiteSpace(kode,nameof(kode));
        Guard.Againts.MaxLength(kode,MaxLength,kode);
        var normalized = kode.Trim().ToUpperInvariant();
        // Tambahkan validasi format
        return new KodeUnitKerja(normalized);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}