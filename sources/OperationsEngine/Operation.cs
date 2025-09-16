namespace OperationEngine;

internal static class Operation
{
    public static IOperation Create<T>(Action<T> action)
        where T : IOperation
    {
        T operation = Activator.CreateInstance<T>();
        action?.Invoke(operation);
        return operation;
    }

    public static async Task ExecuteAsync<T>(Action<T> action)
        where T : IOperation
    {
        T operation = Activator.CreateInstance<T>();
        action?.Invoke(operation);
        await operation.ExecuteAsync();
    }

    public static async Task ExecuteAsync<T>(Func<T, Task> action)
        where T : IOperation
    {
        T operation = Activator.CreateInstance<T>();
        await action?.Invoke(operation);
        await operation.ExecuteAsync();
    }
}
