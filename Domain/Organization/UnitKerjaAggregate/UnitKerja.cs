using Domain.Common.Abstractions;
using Domain.Common.Guards;
using Domain.Organization.UnitKerjaAggregate.ValueObjects;

namespace Domain.Organization.UnitKerjaAggregate;

public sealed class UnitKerja : AggregateRoot
{
    public KodeUnitKerja Kode { get; private set; }
    public string NamaUnitKerja { get; private set; }
    public string? Alamat { get; private set; }

    //Constructor
    private UnitKerja(KodeUnitKerja kode, string namaUnitKerja, string? alamat)
    {
        Kode = kode;
        NamaUnitKerja = namaUnitKerja;
        Alamat = alamat;
    }
    public static UnitKerja Create( string kode, string NamaUnitKerja, string? alamat = null)
    {
        Guard.Againts.NullOrWhiteSpace(NamaUnitKerja,nameof(NamaUnitKerja));
        Guard.Againts.MaxLength(NamaUnitKerja,80,nameof(NamaUnitKerja));
        var unitKerja = new UnitKerja(KodeUnitKerja.Create(kode), NamaUnitKerja.Trim(),alamat?.Trim());
        return unitKerja;
    }
    public void Update(string namaBaru)
    {
        Guard.Againts.NullOrWhiteSpace(namaBaru, nameof(namaBaru));
        Guard.Againts.MaxLength(namaBaru,80, nameof(namaBaru));

        NamaUnitKerja = namaBaru.Trim();
        MarkUpdated();
    }
    public void UpdateAlamat(string? alamatBaru)
    {
        Alamat = alamatBaru?.Trim();
        MarkUpdated();
    }
}