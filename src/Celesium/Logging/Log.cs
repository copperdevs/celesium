// ReSharper disable MemberCanBePrivate.Global

using System.Diagnostics.CodeAnalysis;

namespace CopperDevs.Celesium;

/// <summary>
/// Main log class that holds all the preset log methods
/// </summary>
[SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible")]
public static partial class Log
{
    /// <summary>
    /// Should any logs be written
    /// </summary>
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once ConvertToConstant.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public static bool WritingEnabled = true;

    /// <summary>
    /// Should timestamps be logged alongside the message
    /// </summary>
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once ConvertToConstant.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public static bool IncludeTimestamps = true;

    /// <summary>
    /// Should exceptions logs hide the full stack trace
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
    /// Is temporarily set to <see cref="DuplicatesLogType.Nothing"/> when logging lists while <see cref="ListLogType.Multiple"/> is enabled
    /// </remarks>
    public static DuplicatesLogType DuplicatesLogType = DuplicatesLogType.Nothing;

    /// <summary>
    /// Invoked whenever a log is actually written
    /// </summary>
    /// <remarks>
    /// Ignores <see cref="WritingEnabled"/>
    /// </remarks>
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once ConvertToConstant.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public static Action<LoggedMessage> OnLog = null!;
}