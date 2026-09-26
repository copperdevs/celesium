namespace CopperDevs.Celesium;

public static class LoggingExtensions
{
    extension(LogType logType)
    {
        public string GetDisplayName()
        {
            return logType switch
            {
                LogType.Debug => "Debug",
                LogType.Info => "Information",
                LogType.Runtime => "Runtime",
                LogType.Network => "Network",
                LogType.Success => "Success",
                LogType.Warn => "Warn",
                LogType.Error => "Error",
                LogType.Critical => "Critical",
                LogType.Audit => "Audit",
                LogType.Trace => "Trace",
                LogType.Security => "Security",
                LogType.UserAction => "User Action",
                LogType.Performance => "Performance",
                LogType.Config => "Config",
                LogType.Fatal => "Fatal",
                LogType.Exception => "Exception",
                _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, null)
            };
        }
    }
}