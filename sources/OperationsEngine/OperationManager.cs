namespace OperationsEngine;

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

    public async Task ExecuteAsync<TOperation>(Func<TOperation, Task> action)
        where TOperation : IOperation
    {
        TOperation operation = operationFactory.Create<TOperation>();

        if (action != null)
            await action(operation).ConfigureAwait(false);

        await operation.ExecuteAsync().ConfigureAwait(false);
    }

    public async Task<TResult> ExecuteAsync<TOperation, TResult>(Action<TOperation> action)
        where TOperation : IOperation<TResult>
    {
        TOperation operation = operationFactory.Create<TOperation, TResult>();
        action?.Invoke(operation);
        return await operation.ExecuteAsync();
    }

    public async Task<TResult> ExecuteAsync<TOperation, TResult>(Func<TOperation, Task> action)
        where TOperation : IOperation<TResult>
    {
        TOperation operation = operationFactory.Create<TOperation, TResult>();

        if (action != null)
            await action(operation).ConfigureAwait(false);

        return await operation.ExecuteAsync().ConfigureAwait(false);
    }
}
