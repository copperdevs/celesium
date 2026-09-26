namespace CopperDevs.Celesium;

public readonly struct LoggedMessage
{
    public readonly LogType Type;
    public readonly string Contents;
    public readonly string Prefix;
    public readonly long LoggedAt;
    
    public LoggedMessage(LogType type, long loggedAt, string prefix, string contents)
    {
        Type = type;
        LoggedAt = loggedAt;
        Prefix = prefix;
        Contents = contents;
    }
}