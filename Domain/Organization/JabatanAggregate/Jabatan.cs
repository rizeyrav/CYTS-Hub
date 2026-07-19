namespace Domain.Organization.JabatanAggregate;
using Domain.Common.Abstractions;
using Domain.Common.Guards;
using Domain.Organization.Exceptions;
using Domain.Organization.JabatanAggregate.ValueObjects;

public sealed class Jabatan : AggregateRoot {
    public KodeJabatan Kode { get; private set; }
    public string NamaJabatan { get; private set; }
    public int HierarkiLevel { get; private set; }
    public bool IsStruktural { get; private set; }

    private Jabatan(KodeJabatan kode, string namaJabatan, int hierarkiLevel, bool isStruktural)
    {
        Kode = kode;
        NamaJabatan = namaJabatan;
        HierarkiLevel = hierarkiLevel;
        IsStruktural = isStruktural;
    }
    public static Jabatan Create(string kode, string namaJabatan, int hierarkiLevel, bool isStruktural)
    {
        Guard.Againts.NullOrWhiteSpace(namaJabatan,nameof(namaJabatan));
        Guard.Againts.MaxLength(namaJabatan, 50, nameof(namaJabatan));
        // Karena level 0 kemungkinan valid untuk jabatan non-struktural
        Guard.Againts.Negative(hierarkiLevel,nameof(hierarkiLevel));
        
        return new Jabatan(KodeJabatan.Create(kode), namaJabatan.Trim(), hierarkiLevel, isStruktural);
    }
    public void UpdateJabatan(string jabatanBaru)
    {
        Guard.Againts.NullOrWhiteSpace(jabatanBaru, nameof(jabatanBaru));
        Guard.Againts.MaxLength(jabatanBaru, 50, nameof(jabatanBaru));
        NamaJabatan = jabatanBaru.Trim();
        MarkUpdated();
    }
    // Business Rules
    public void UpdateHierarki(int levelBaru)
    {
        Guard.Againts.Negative(levelBaru,nameof(levelBaru));
        if(IsStruktural && levelBaru == 0)
            throw new OrganizationException("Jabatan tidak boleh memiliki hierarki level 0");
        HierarkiLevel = levelBaru;
        MarkUpdated();       
    }
}