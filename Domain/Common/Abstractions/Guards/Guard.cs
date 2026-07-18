namespace Domain.Common.Guards;

public static class Guard
{
    public static IGuardClause Againts { get; } = new GuardClasuse();
}

public interface IGuardClause
{

}

internal sealed class GuardClasuse : IGuardClause
{
    
}

public static class GuardClasuseExtensions
{
    public static string NullOrWhiteSpace(this IGuardClause guard, string? input, string parameterName)
    {
        if(input is null)
        throw new ArgumentNullException(parameterName);

        if(string.IsNullOrWhiteSpace(input))
        throw new ArgumentException("Nilai tidak boleh kosong");
        return input;
    }
    public static Guid NullOrEmpty(this IGuardClause guard, Guid input, string parameterName)
    {
        if(input==Guid.Empty)
            throw new ArgumentException("Id tidak boleh kosong (Guid.Empty)",parameterName);
        return input;
    }
    public static int Negative(this IGuardClause guard,int input, string parameterName)
    {
        if (input < 0)
            throw new ArgumentException("Nilai tidak boleh negative", parameterName);
        return input; 
    }
    public static int NegativeOrZero(this IGuardClause guard,int input, string parameterName)
    {
        if (input <= 0)
            throw new ArgumentException("Nilai tidak boleh negative", parameterName);
        return input; 
    }
    public static string MaxLength(this IGuardClause guard,string input,int MaxLength, string parameterName)
    {
        if (input.Length > MaxLength)
            throw new ArgumentException($"Panjang maksimal {MaxLength} karakter",parameterName);
        return input; 
    }
    public static void OutOfRange(this IGuardClause guard, DateTime start, DateTime end,string parameterName)
    {
        if(end < start )
            throw new ArgumentException("Tanggal selesai tidak boleh sebelum tanggal mulai");
    }
}