using Domain.Common.Abstractions;
using Domain.Common.Guards;
using Domain.Organization.Exceptions;
using Domain.Organization.FormasiAggregate.ValueObjects;

namespace Domain.Organization.FormasiAggregate;

public sealed class Formasi : AggregateRoot
{
    public Guid BidangId { get; private set; }
    public Guid JabatanId { get; private set; }
    public KodeFormasi Kode { get; private set; }
    public string NamaFormasi { get; private set; }
    public int JumlahFormasi { get; private set; }
    public StatusFormasi Status { get; private set; }
    public bool IsActive { get; private set; }
    private Formasi(Guid bidangId, Guid jabatanId, KodeFormasi kode, string namaFormasi, int jumlahFormasi)
    {
        BidangId = bidangId;
        JabatanId = jabatanId;
        Kode = kode;
        NamaFormasi = namaFormasi;
        JumlahFormasi = jumlahFormasi;
        Status = StatusFormasi.Diajukan;
        IsActive = true;
    }
    public static Formasi Create(Guid bidangId, Guid jabatanId, String kode, string namaFormasi, int jumlahFormasi
    )
    {
        Guard.Againts.NullOrEmpty(bidangId,nameof(bidangId));
        Guard.Againts.NullOrEmpty(jabatanId,nameof(jabatanId));
        Guard.Againts.NullOrWhiteSpace(namaFormasi,nameof(namaFormasi));
        Guard.Againts.Negative(jumlahFormasi,nameof(jumlahFormasi));


        return new Formasi(bidangId, jabatanId, KodeFormasi.Create(kode), namaFormasi.Trim(), jumlahFormasi);
    }
    public void UpdateJumlah (int jumlahBaru)
    {
        Guard.Againts.Negative(jumlahBaru,nameof(jumlahBaru));
        if(Status == StatusFormasi.Ditutup)
            throw new OrganizationException("Formasi ditutup tidak bisa dirubah jumlahnya");
        JumlahFormasi = jumlahBaru;
        MarkUpdated();
    }
    public void Setujui()
    {
        if(Status != StatusFormasi.Diajukan)
            throw new OrganizationException("Hanya formasi berstatus Diajukan yang bisa disetujui");
        MarkUpdated();
    }
    public void Tolak()
    {
        if(Status != StatusFormasi.Diajukan)
            throw new OrganizationException("Hanya formasi berstatus Diajukan yang bisa ditolak");
        MarkUpdated();
    }
    public void Tutup()
    {
        if(Status != StatusFormasi.Disetujui)
            throw new OrganizationException("Hanya formasi yang sudah disetujui yang bisa ditutup");
        Status = StatusFormasi.Ditutup;
        IsActive = false;
        MarkUpdated();
    }
}