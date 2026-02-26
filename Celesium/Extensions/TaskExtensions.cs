namespace CopperDevs.Celesium;

public static class TaskExtensions
{
    extension(Task)
    {
        public static void BackgroundRun(Func<Task?> function)
        {
            Task.Run(function);
        }
    }
}