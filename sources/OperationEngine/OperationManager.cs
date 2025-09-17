namespace DustInTheWInd.OperationEngine;

public class OperationManager
{
    private readonly IOperationFactory operationFactory;

    public OperationManager(IOperationFactory operationFactory)
    {
        this.operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
    }

    public async Task ExecuteAsync<T>(Action<T> init = null)
        where T : IOperation
    {
        T operation = operationFactory.Create<T>();
        init?.Invoke(operation);

        await operation.ExecuteAsync()
            .ConfigureAwait(false);
    }

    public async Task<TResult> ExecuteAsync<TOperation, TResult>(Action<TOperation> init = null)
        where TOperation : IOperation<TResult>
    {
        TOperation operation = operationFactory.Create<TOperation, TResult>();
        init?.Invoke(operation);

        return await operation.ExecuteAsync()
            .ConfigureAwait(false);
    }
}
