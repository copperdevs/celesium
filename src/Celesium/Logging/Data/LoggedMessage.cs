namespace CopperDevs.Celesium;

/// <summary>
/// Context of a message that has been logged 
/// </summary>
public readonly struct LoggedMessage
{
    // self-explanatory i fear
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public readonly LogType Type;
    public readonly string Contents;
    public readonly string Prefix;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// Milliseconds since Unix Epoch
    /// </summary>
    public readonly long LoggedAt;

    // dude it's a constructor
    // it constructs
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public LoggedMessage(LogType type, long loggedAt, string prefix, string contents)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Type = type;
        LoggedAt = loggedAt;
        Prefix = prefix;
        Contents = contents;
    }
}