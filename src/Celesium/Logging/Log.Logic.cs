using System.Collections;

namespace CopperDevs.Celesium;

public static partial class Log
{
    internal static void LogMessage(AnsiColors.Names colorName, object message, bool shouldLog, LogType logType, string? category)
    {
        if (shouldLog)
            LogMessage(colorName, logType.GetDisplayName(), message, logType, category);
    }

    private static void LogMessage(AnsiColors.Names colorName, string prefix, object message, LogType logType, string? category)
    {
        var utcNow = DateTime.UtcNow;
        var timeNow = TimeUtility.MillisecondsFrom01Jan1970(utcNow);

        if (HandleList(colorName, prefix, message, logType, category))
            return;

        // you never know sadly
        // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
        message ??= "null";

        switch (message)
        {
            case Exception exception:
                LogException(colorName, prefix, exception, logType, category);
                return;
            case List<string> list:
                LogList(colorName, prefix, list, logType, utcNow, category);
                return;
        }

        var color = AnsiColors.GetColor(colorName);
        var backgroundColor = AnsiColors.GetBackgroundColor(colorName);

        var time = IncludeTimestamps ? $"{utcNow:HH:mm:ss}" : "";
        var timeSpacer = IncludeTimestamps ? " " : "";

        var timeText = $"{AnsiColors.Black}{AnsiColors.LightGrayBackground}{time}{AnsiColors.Black}{AnsiColors.Reset}{timeSpacer}";
        var categoryText = category is not null ? $"{AnsiColors.Black}{AnsiColors.LightGrayBackground}{category}{AnsiColors.Reset} " : string.Empty;
        var prefixText = $"{backgroundColor}{prefix}:{AnsiColors.Reset}";

        var context = new LoggedMessage(logType, timeNow, prefix, message.ToString()!);
        Write($"{timeText}{categoryText}{prefixText} {color}{message}", timeText, context);
    }

    private static bool HandleList(AnsiColors.Names colorName, string prefix, object message, LogType logType, string? category)
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
            LogMessage(colorName, prefix, moment, logType, category);
            return true;
        }

        // we properly log this specific case elsewhere, so just return from here
        if (message.GetType() == typeof(List<string>)) return false;

        var stringList = ((IList)message)
            .Cast<object?>()
            .Select(item => (item ?? "null").ToString())
            .ToList();

        LogMessage(colorName, prefix, stringList, logType, category);
        return true;
    }

    private static void LogException(AnsiColors.Names colorName, string prefix, Exception exception, LogType logType, string? category)
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
        LogMessage(colorName, prefix, lines, logType, category);
        ListLogType = current;
    }

    private static void LogList(AnsiColors.Names colorName, string prefix, List<string> list, LogType logType, DateTime utcNow, string? category)
    {
        var prunedList = list.Where(item => !string.IsNullOrWhiteSpace(item)).ToList();

        var timeNow = TimeUtility.MillisecondsFrom01Jan1970(utcNow);

        var color = AnsiColors.GetColor(colorName);
        var backgroundColor = AnsiColors.GetBackgroundColor(colorName);

        var time = IncludeTimestamps ? $"{utcNow:HH:mm:ss}" : "";
        var timeSpacer = IncludeTimestamps ? " " : "";

        var timeText = $"{AnsiColors.Black}{AnsiColors.LightGrayBackground}{time}{AnsiColors.Black}{AnsiColors.Reset}{timeSpacer}";
        var prefixText = $"{backgroundColor}{prefix}:{AnsiColors.Reset}";
        var rawPrefixText = $"{time}{timeSpacer}{(category is not null ? $"{category} " : "")}{prefix}: "; // can't use prefixText&timeText for length of text due to AnsiColors coloring
        var categoryText = category is not null ? $"{AnsiColors.Black}{AnsiColors.LightGrayBackground}{category}{AnsiColors.Reset} " : string.Empty;

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

        var context = new LoggedMessage(logType, timeNow, prefix, prunedList.Count == 1 ? prunedList[0] : string.Join(Environment.NewLine, prunedList));
        Write($"{timeText}{categoryText}{prefixText} {color}{result}", timeText, context);

        DuplicatesLogType = previous;

        return;

        string GetResult(string firstPos, string firstNeg, string lastPos, string lastNeg)
        {
            var finalResult = string.Empty;

            for (var i = 0; i < prunedList.Count; i++)
            {
                var first = i == 0;
                var last = i == prunedList.Count - 1;
                // you never know sadly
                // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
                var item = (prunedList[i] ?? "null").TrimStart();

                if (!string.IsNullOrWhiteSpace(item))
                    finalResult += $"{(first ? firstPos : firstNeg)}{item}{(last ? lastPos : lastNeg)}";
            }

            return finalResult;
        }
    }

    private static string? previousMessage;
    private static int previousMessageCount = 1;

    private static void Write(string finalMessage, string timeMessageContent, LoggedMessage context)
    {
        OnLog?.Invoke(context);
        if (!WritingEnabled)
            return;

        var extra = string.Empty;

        if (DuplicatesLogType != DuplicatesLogType.Nothing)
        {
            var msg = DuplicatesLogType switch
            {
                DuplicatesLogType.Numbered => finalMessage,
                DuplicatesLogType.IgnoreTime => finalMessage.Remove(0, timeMessageContent.Length),
                _ => throw new ArgumentOutOfRangeException()
            };

            var isSame = previousMessage == msg;

            if (isSame)
            {
                previousMessageCount++;

                if (Console.CursorTop > 0)
                    Console.CursorTop--;
            }
            else
            {
                previousMessageCount = 1;
            }

            previousMessage = msg;

            extra = previousMessageCount > 1 ? $" x{previousMessageCount}" : "";

            Console.Write("\r" + new string(' ', Console.BufferWidth - 1) + "\r");
        }

        Console.Write($"{finalMessage}{AnsiColors.Reset}{extra}{Environment.NewLine}");
    }
}