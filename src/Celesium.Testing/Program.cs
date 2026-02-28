using CopperDevs.Celesium;

namespace Celesium.Testing;

public static class Program
{
    public static void Main()
    {
        Log.Info(null!);
        
        Log.Info(new List<string>()
        {
            "test",
            "test 1",
            null!,
            "test 2",
        });
    }
}