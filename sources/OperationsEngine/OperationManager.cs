namespace OperationEngine;

public class OperationManager
{
    private readonly IOperationFactory operationFactory;

    public OperationManager(IOperationFactory operationFactory)
    {
        this.operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
    }

    public async Task ExecuteAsync<T>(Action<T> action)
        where T : IOperation
    {
        T operation = operationFactory.Create<T>();
        action?.Invoke(operation);
        await operation.ExecuteAsync();
    }

    public async Task ExecuteAsync<T>(Func<T, Task> action)
        where T : IOperation
    {
        T operation = operationFactory.Create<T>();
        await action?.Invoke(operation);
        await operation.ExecuteAsync();
    }
}
