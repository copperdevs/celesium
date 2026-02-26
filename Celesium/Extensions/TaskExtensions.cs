namespace CopperDevs.Celesium;

public static class TaskExtensions
{
    extension(Task)
    {
        public static void BackgroundRun(Func<Task?> function)
        {
            Task.Run(function);
        }

        public static void BackgroundRun(Action action)
        {
            Task.Run(action);
        }
    }
}