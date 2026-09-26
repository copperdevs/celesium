using System.Text.Json;
using CopperDevs.Celesium;

namespace Celesium.Testing;

public static class Program
{
    public static void Main()
    {
        Log.OnLog += message => Console.WriteLine(JsonSerializer.Serialize(message));

        TestLogHolder(Log.Debug, Log.Debug);
        TestLogHolder(Log.Info, Log.Info);
        TestLogHolder(Log.Runtime, Log.Runtime);
        TestLogHolder(Log.Network, Log.Network);
        TestLogHolder(Log.Success, Log.Success);
        TestLogHolder(Log.Warn, Log.Warn);
        TestLogHolder(Log.Error, Log.Error);
        TestLogHolder(Log.Critical, Log.Critical);
        TestLogHolder(Log.Audit, Log.Audit);
        TestLogHolder(Log.Trace, Log.Trace);
        TestLogHolder(Log.Security, Log.Security);
        TestLogHolder(Log.UserAction, Log.UserAction);
        TestLogHolder(Log.Performance, Log.Performance);
        TestLogHolder(Log.Config, Log.Config);
        TestLogHolder(Log.Fatal, Log.Fatal);

        Log.Exception(new Exception("Test Exception"));
        Log.Exception(new Exception("Test Exception"), "Category");
    }

    public static void TestLogHolder(Action<object> baseLog, Action<object, string> categoryLog)
    {
        baseLog?.Invoke("Log Test");
        categoryLog?.Invoke("Log Category", "Category");

        baseLog?.Invoke
        (
            new List<string>
            {
                "test 1",
                "test 2",
                "test 3",
            }
        );
        categoryLog?.Invoke
        (
            new List<string>
            {
                "test 1",
                "test 2",
                "test 3",
            },
            "Category"
        );
    }
}