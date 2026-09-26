namespace CopperDevs.Celesium;

public static class TimeUtility
{
    public static long UtcNow() => MillisecondsFrom01Jan1970(DateTime.UtcNow);

    public static readonly DateTime Date01Jan1970 = new(1970, 1, 1);

    public static long MillisecondsFrom01Jan1970(DateTime dt) => (dt.Ticks - Date01Jan1970.Ticks) / TimeSpan.TicksPerMillisecond;
}