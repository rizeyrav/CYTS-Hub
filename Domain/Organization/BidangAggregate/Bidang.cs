using Domain.Common.Abstractions;
using Domain.Common.Guards;
using Domain.Organization.UnitKerjaAggregate.ValueObjects;

namespace Domain.Organization.BidangAggregate;

public sealed class Bidang : AggregateRoot
{
    // sengaja bertipe Guid polos, bukan UnitKerja UnitKerja { get; }
    // menegakkan aturan aggregate boundary
    // tidak boleh menyimpan referensi objek langsung ke aggregate lain

    public Guid UnitKerjaId { get; private set; }
    public KodeBidang Kode { get; private set; }
    public string NamaBidang { get; private set; }

    private Bidang(Guid unitKerjaId, KodeBidang kode, string namaBidang)
    {
        UnitKerjaId = unitKerjaId;
        Kode = kode;
        NamaBidang = namaBidang;
    }
    public static Bidang Create(Guid unitKerjaId, string kode, string namaBidang)
    {
        Guard.Againts.NullOrEmpty(unitKerjaId, nameof(unitKerjaId));
        Guard.Againts.NullOrWhiteSpace(namaBidang, nameof(namaBidang));
        Guard.Againts.MaxLength(namaBidang,100, nameof(namaBidang));
        return new Bidang(unitKerjaId, KodeBidang.Create(kode), namaBidang.Trim());
    }
    public void Update(string namaBaru)
    {
        Guard.Againts.NullOrWhiteSpace(namaBaru, nameof(namaBaru));
        Guard.Againts.MaxLength(namaBaru,100, nameof(namaBaru));

        NamaBidang = namaBaru.Trim();
        MarkUpdated();
    }
    public void MoveUnitKerja(Guid unitKerjaIdBaru)
    {
        Guard.Againts.NullOrEmpty(unitKerjaIdBaru,nameof(unitKerjaIdBaru));
        UnitKerjaId = unitKerjaIdBaru;
        MarkUpdated();
    }
}