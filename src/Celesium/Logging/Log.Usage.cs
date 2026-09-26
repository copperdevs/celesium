namespace CopperDevs.Celesium;

public static partial class Log
{
    /// <summary>
    /// Log a debug style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Debug(object message) => Debug(message, true);

    /// <summary>
    /// Log a debug style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Debug(object message, bool condition) => LogMessage(AnsiColors.Names.Gray, message, condition, LogType.Debug, null);

    /// <summary>
    /// Log a debug style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Debug(object message, string category) => Debug(message, category, true);

    /// <summary>
    /// Log a debug style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Debug(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Gray, message, condition, LogType.Debug, category);

    /// <summary>
    /// Log an info style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Info(object message) => Info(message, true);

    /// <summary>
    /// Log an info style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Info(object message, bool condition) => LogMessage(AnsiColors.Names.Cyan, message, condition, LogType.Info, null);

    /// <summary>
    /// Log an info style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Info(object message, string category) => Info(message, category, true);

    /// <summary>
    /// Log an info style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Info(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Cyan, message, condition, LogType.Info, category);

    /// <summary>
    /// Log a runtime style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Runtime(object message) => Runtime(message, true);

    /// <summary>
    /// Log a runtime style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Runtime(object message, bool condition) => LogMessage(AnsiColors.Names.Magenta, message, condition, LogType.Runtime, null);

    /// <summary>
    /// Log a runtime style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Runtime(object message, string category) => Runtime(message, category, true);

    /// <summary>
    /// Log a runtime style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Runtime(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Magenta, message, condition, LogType.Runtime, category);

    /// <summary>
    /// Log a network style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Network(object message) => Network(message, true);

    /// <summary>
    /// Log a network style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Network(object message, bool condition) => LogMessage(AnsiColors.Names.Blue, message, condition, LogType.Network, null);

    /// <summary>
    /// Log a network style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Network(object message, string category) => Network(message, category, true);

    /// <summary>
    /// Log a network style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Network(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Blue, message, condition, LogType.Network, category);

    /// <summary>
    /// Log a success style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Success(object message) => Success(message, true);

    /// <summary>
    /// Log a success style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Success(object message, bool condition) => LogMessage(AnsiColors.Names.BrightGreen, message, condition, LogType.Success, null);

    /// <summary>
    /// Log a success style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Success(object message, string category) => Success(message, category, true);

    /// <summary>
    /// Log a success style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Success(object message, string category, bool condition) => LogMessage(AnsiColors.Names.BrightGreen, message, condition, LogType.Success, category);

    /// <summary>
    /// Log a warning style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Warn(object message) => Warn(message, true);

    /// <summary>
    /// Log a warning style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Warn(object message, bool condition) => LogMessage(AnsiColors.Names.BrightYellow, message, condition, LogType.Warn, null);

    /// <summary>
    /// Log a warning style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Warn(object message, string category) => Warn(message, category, true);

    /// <summary>
    /// Log a warning style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Warn(object message, string category, bool condition) => LogMessage(AnsiColors.Names.BrightYellow, message, condition, LogType.Warn, category);

    /// <summary>
    /// Log an error style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Error(object message) => Error(message, true);

    /// <summary>
    /// Log an error style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Error(object message, bool condition) => LogMessage(AnsiColors.Names.Red, message, condition, LogType.Error, null);

    /// <summary>
    /// Log an error style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Error(object message, string category) => Error(message, category, true);

    /// <summary>
    /// Log an error style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Error(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Red, message, condition, LogType.Error, category);

    /// <summary>
    /// Log a critical style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Critical(object message) => Critical(message, true);

    /// <summary>
    /// Log a critical style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Critical(object message, bool condition) => LogMessage(AnsiColors.Names.BrightRed, message, condition, LogType.Critical, null);

    /// <summary>
    /// Log a critical style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Critical(object message, string category) => Critical(message, category, true);

    /// <summary>
    /// Log a critical style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Critical(object message, string category, bool condition) => LogMessage(AnsiColors.Names.BrightRed, message, condition, LogType.Critical, category);

    /// <summary>
    /// Log an audit style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Audit(object message) => Audit(message, true);

    /// <summary>
    /// Log an audit style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Audit(object message, bool condition) => LogMessage(AnsiColors.Names.Yellow, message, condition, LogType.Audit, null);

    /// <summary>
    /// Log an audit style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Audit(object message, string category) => Audit(message, category, true);

    /// <summary>
    /// Log an audit style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Audit(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Yellow, message, condition, LogType.Audit, category);

    /// <summary>
    /// Log a trace style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Trace(object message) => Trace(message, true);

    /// <summary>
    /// Log a trace style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Trace(object message, bool condition) => LogMessage(AnsiColors.Names.LightBlue, message, condition, LogType.Trace, null);

    /// <summary>
    /// Log a trace style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Trace(object message, string category) => Trace(message, category, true);

    /// <summary>
    /// Log a trace style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Trace(object message, string category, bool condition) => LogMessage(AnsiColors.Names.LightBlue, message, condition, LogType.Trace, category);

    /// <summary>
    /// Log a security style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Security(object message) => Security(message, true);

    /// <summary>
    /// Log a security style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Security(object message, bool condition) => LogMessage(AnsiColors.Names.Purple, message, condition, LogType.Security, null);

    /// <summary>
    /// Log a security style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Security(object message, string category) => Security(message, category, true);

    /// <summary>
    /// Log a security style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Security(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Purple, message, condition, LogType.Security, category);

    /// <summary>
    /// Log a user action style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void UserAction(object message) => UserAction(message, true);

    /// <summary>
    /// Log a user action style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void UserAction(object message, bool condition) => LogMessage(AnsiColors.Names.CutePink, message, condition, LogType.UserAction, null);

    /// <summary>
    /// Log a user action style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void UserAction(object message, string category) => UserAction(message, category, true);

    /// <summary>
    /// Log a user action style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void UserAction(object message, string category, bool condition) => LogMessage(AnsiColors.Names.CutePink, message, condition, LogType.UserAction, category);

    /// <summary>
    /// Log a performance style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Performance(object message) => Performance(message, true);

    /// <summary>
    /// Log a performance style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Performance(object message, bool condition) => LogMessage(AnsiColors.Names.Pink, message, condition, LogType.Performance, null);

    /// <summary>
    /// Log a performance style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Performance(object message, string category) => Performance(message, category, true);

    /// <summary>
    /// Log a performance style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Performance(object message, string category, bool condition) => LogMessage(AnsiColors.Names.Pink, message, condition, LogType.Performance, category);

    /// <summary>
    /// Log a config style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Config(object message) => Config(message, true);

    /// <summary>
    /// Log a config style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Config(object message, bool condition) => LogMessage(AnsiColors.Names.LightGray, message, condition, LogType.Config, null);

    /// <summary>
    /// Log a config style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Config(object message, string category) => Config(message, category, true);

    /// <summary>
    /// Log a config style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Config(object message, string category, bool condition) => LogMessage(AnsiColors.Names.LightGray, message, condition, LogType.Config, category);

    /// <summary>
    /// Log a fatal style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    public static void Fatal(object message) => Fatal(message, true);

    /// <summary>
    /// Log a fatal style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Fatal(object message, bool condition) => LogMessage(AnsiColors.Names.DarkRed, message, condition, LogType.Fatal, null);

    /// <summary>
    /// Log a fatal style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Fatal(object message, string category) => Fatal(message, category, true);

    /// <summary>
    /// Log a fatal style log to the console
    /// </summary>
    /// <param name="message">Data to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Fatal(object message, string category, bool condition) => LogMessage(AnsiColors.Names.DarkRed, message, condition, LogType.Fatal, category);

    /// <summary>
    /// Log an exception to the console
    /// </summary>
    /// <param name="exception">Exception to log</param>
    public static void Exception(Exception exception) => Exception(exception, true);

    /// <summary>
    /// Log an exception to the console
    /// </summary>
    /// <param name="exception">Exception to log</param>
    /// <param name="condition">Should the message actually log</param>
    public static void Exception(Exception exception, bool condition) => LogMessage(AnsiColors.Names.Red, exception, condition, LogType.Exception, null);

    /// <summary>
    /// Log an exception to the console
    /// </summary>
    /// <param name="exception">Exception to log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Exception(Exception exception, string category) => Exception(exception, category, true);

    /// <summary>
    /// Log an exception to the console
    /// </summary>
    /// <param name="exception">Exception to log</param>
    /// <param name="condition">Should the message actually log</param>
    /// <param name="category">Which category to display the log under</param>
    public static void Exception(Exception exception, string category, bool condition) => LogMessage(AnsiColors.Names.Red, exception, condition, LogType.Exception, category);
}