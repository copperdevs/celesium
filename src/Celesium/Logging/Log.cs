using System.Collections;

// ReSharper disable MemberCanBePrivate.Global

namespace CopperDevs.Celesium;

/// <summary>
/// Main log class that holds all the preset log methods
/// </summary>
public static class Log
{
    /// <summary>
    /// Should timestamps be logged alongside the message
    /// </summary>
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once ConvertToConstant.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public static bool IncludeTimestamps = true;

    /// <summary>
    /// Should exceptions logs include the full stack trace
    /// </summary>
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once ConvertToConstant.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public static bool SimpleExceptions = false;

    /// <summary>
    /// How lists should be printed to console
    /// </summary>
    public static ListLogType ListLogType = ListLogType.Multiple;

    /// <summary>
    /// How duplicate messages with the same contents should be logged
    /// </summary>
    /// <remarks>
    /// Is temporarily set to <see cref="DuplicatesLogType.Nothing"/> when logging lists with <see cref="ListLogType.Multiple"/> enabled
    /// </remarks>
    public static DuplicatesLogType DuplicatesLogType = DuplicatesLogType.Nothing;

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
    public static void Debug(object message, bool condition) => LogMessage(AnsiColors.Names.Gray, "Debug", message, condition);

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
    public static void Info(object message, bool condition) => LogMessage(AnsiColors.Names.Cyan, "Information", message, condition);

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
    public static void Runtime(object message, bool condition) => LogMessage(AnsiColors.Names.Magenta, "Runtime", message, condition);

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
    public static void Network(object message, bool condition) => LogMessage(AnsiColors.Names.Blue, "Network", message, condition);

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
    public static void Success(object message, bool condition) => LogMessage(AnsiColors.Names.BrightGreen, "Success", message, condition);

    /// <summary>
    /// Use <see cref="Warn(object)"/>
    /// </summary>
    /// <param name="message">Data to log</param>
    /// 
    [Obsolete("Use Log.Warn")]
    public static void Warning(object message) => Warn(message);

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
    public static void Warn(object message, bool condition) => LogMessage(AnsiColors.Names.BrightYellow, "Warning", message, condition);

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
    public static void Error(object message, bool condition) => LogMessage(AnsiColors.Names.Red, "Error", message, condition);

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
    public static void Critical(object message, bool condition) => LogMessage(AnsiColors.Names.BrightRed, "Critical", message, condition);

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
    public static void Audit(object message, bool condition) => LogMessage(AnsiColors.Names.Yellow, "Audit", message, condition);

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
    public static void Trace(object message, bool condition) => LogMessage(AnsiColors.Names.LightBlue, "Trace", message, condition);

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
    public static void Security(object message, bool condition) => LogMessage(AnsiColors.Names.Purple, "Security", message, condition);

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
    public static void UserAction(object message, bool condition) => LogMessage(AnsiColors.Names.CutePink, "User Action", message, condition);

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
    public static void Performance(object message, bool condition) => LogMessage(AnsiColors.Names.Pink, "Performance", message, condition);

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
    public static void Config(object message, bool condition) => LogMessage(AnsiColors.Names.LightGray, "Config", message, condition);

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
    public static void Fatal(object message, bool condition) => LogMessage(AnsiColors.Names.DarkRed, "Fatal", message, condition);

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
    public static void Exception(Exception exception, bool condition) => LogMessage(AnsiColors.Names.Red, "Exception", exception, condition);

    internal static void LogMessage(AnsiColors.Names colorName, string prefix, object message, bool shouldLog)
    {
        if (shouldLog)
            LogMessage(colorName, colorName, prefix, message);
    }

    private static void LogMessage(AnsiColors.Names colorName, AnsiColors.Names backgroundColorName, string prefix, object message)
    {
        if (HandleList(colorName, backgroundColorName, prefix, message))
            return;

        // you never know sadly
        // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
        message ??= "null";

        switch (message)
        {
            case Exception exception:
                LogException(colorName, backgroundColorName, prefix, exception);
                return;
            case List<string> list:
                LogList(colorName, backgroundColorName, prefix, list);
                return;
        }

        var color = AnsiColors.GetColor(colorName);
        var backgroundColor = AnsiColors.GetBackgroundColor(backgroundColorName);

        var time = IncludeTimestamps ? $"{DateTime.Now:HH:mm:ss}" : "";
        var timeSpacer = IncludeTimestamps ? " " : "";

        var timeText = $"{AnsiColors.Black}{AnsiColors.LightGrayBackground}{time}{AnsiColors.Reset}{AnsiColors.Black}{timeSpacer}";
        var prefixText = $"{backgroundColor}{prefix}:{AnsiColors.Reset}";

        Write($"{timeText}{prefixText} {color}{message}", timeText);
    }

    private static bool HandleList(AnsiColors.Names colorName, AnsiColors.Names backgroundColorName, string prefix, object message)
    {
        // you never know sadly
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (message == null)
            return false;
        
        var isCollection = (
                               message.GetType() is { IsGenericType: true } &&
                               message.GetType().GetGenericTypeDefinition() == typeof(List<>)
                           )
                           || message.GetType().IsArray;

        if (!isCollection)
            return false;

        if (ListLogType == ListLogType.Direct)
        {
            var moment = $"{message}";
            LogMessage(colorName, backgroundColorName, prefix, moment);
            return true;
        }

        // we properly log this specific case elsewhere, so just return from here
        if (message.GetType() == typeof(List<string>)) return false;

        var stringList = ((IList)message)
            .Cast<object?>()
            .Select(item => (item ?? "null").ToString())
            .ToList();

        LogMessage(colorName, backgroundColorName, prefix, stringList);
        return true;
    }

    private static void LogException(AnsiColors.Names colorName, AnsiColors.Names backgroundColorName, string prefix, Exception exception)
    {
        var lines = new List<string>
        {
            exception.Message,
            SimpleExceptions ? $"{exception.TargetSite} in {exception.Source}" : string.Empty
        };

        if (!SimpleExceptions)
        {
            lines.AddRange((exception.StackTrace ?? string.Empty).Split(
                [
                    Environment.NewLine
                ],
                StringSplitOptions.RemoveEmptyEntries)
            );
        }

        var current = ListLogType;
        ListLogType = ListLogType.Multiple;
        LogMessage(colorName, backgroundColorName, prefix, lines);
        ListLogType = current;
    }

    private static void LogList(AnsiColors.Names colorName, AnsiColors.Names backgroundColorName, string prefix, List<string> list)
    {
        var color = AnsiColors.GetColor(colorName);
        var backgroundColor = AnsiColors.GetBackgroundColor(backgroundColorName);

        var time = IncludeTimestamps ? $"{DateTime.Now:HH:mm:ss}" : "";
        var timeSpacer = IncludeTimestamps ? " " : "";

        var timeText = $"{AnsiColors.Black}{AnsiColors.LightGrayBackground}{time}{AnsiColors.Reset}{AnsiColors.Black}{timeSpacer}";
        var prefixText = $"{backgroundColor}{prefix}:{AnsiColors.Reset}";
        var rawPrefixText = $"{time}{timeSpacer}{prefix}: "; // can't use prefixText&timeText for length of text due to AnsiColors coloring

        // we don't handle ListLogType.Direct here because it's handled earlier in HandleList so the proper types can be logged instead of a string list
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        var result = ListLogType switch
        {
            ListLogType.Multiple => GetResult
            (
                string.Empty,
                string.Empty.PadLeft(rawPrefixText.Length),
                string.Empty,
                Environment.NewLine
            ),
            ListLogType.Single => GetResult
            (
                "[",
                ",",
                "]",
                string.Empty
            ),
            _ => throw new ArgumentOutOfRangeException()
        };

        var previous = DuplicatesLogType;

        if (ListLogType == ListLogType.Multiple)
            previous = DuplicatesLogType.Nothing;

        Write($"{timeText}{prefixText} {color}{result}", timeText);

        DuplicatesLogType = previous;

        return;

        string GetResult(string firstPos, string firstNeg, string lastPos, string lastNeg)
        {
            var finalResult = string.Empty;

            for (var i = 0; i < list.Count; i++)
            {
                var first = i == 0;
                var last = i == list.Count - 1;
                // you never know sadly
                // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
                var item = (list[i] ?? "null").TrimStart();

                if (!string.IsNullOrWhiteSpace(item))
                    finalResult += $"{(first ? firstPos : firstNeg)}{item}{(last ? lastPos : lastNeg)}";
            }

            return finalResult;
        }
    }

    private static string? previousMessage;
    private static int previousMessageCount = 1;

    private static void Write(string message, string time)
    {
        var extra = string.Empty;

        if (DuplicatesLogType != DuplicatesLogType.Nothing)
        {
            var msg = DuplicatesLogType switch
            {
                DuplicatesLogType.Numbered => message,
                DuplicatesLogType.IgnoreTime => message.Remove(0, time.Length),
                _ => throw new ArgumentOutOfRangeException()
            };

            var isSame = previousMessage == msg;

            if (isSame)
            {
                previousMessageCount++;

                // Move up one line safely
                if (Console.CursorTop > 0)
                    Console.CursorTop--;
            }
            else
            {
                previousMessageCount = 1;
            }

            previousMessage = msg;

            // Build the suffix only when count > 1
            extra = previousMessageCount > 1 ? $" x{previousMessageCount}" : "";

            // Clear the whole line before writing
            Console.Write("\r" + new string(' ', Console.BufferWidth - 1) + "\r");
        }

        Console.Write($"{message}{AnsiColors.Reset}{extra}{Environment.NewLine}");
    }
}