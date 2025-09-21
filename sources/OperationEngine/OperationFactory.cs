namespace DustInTheWInd.OperationEngine;

public class OperationFactory
{
    private readonly IOperationFactory operationFactory;

    public OperationFactory(IOperationFactory operationFactory)
    {
        this.operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
    }

    public OperationBuilder<T> Create<T>()
        where T : IOperation
    {
        T operation = operationFactory.Create<T>();
        return new OperationBuilder<T>(operation);
    }

    public OperationBuilder<TOperation, TResult> Create<TOperation, TResult>()
        where TOperation : IOperation<TResult>
    {
        TOperation operation = operationFactory.Create<TOperation, TResult>();
        return new OperationBuilder<TOperation, TResult>(operation);
    }

    public async Task CreateAndExecuteAsync<T>(Action<T> init = null)
        where T : IOperation
    {
        T operation = operationFactory.Create<T>();
        init?.Invoke(operation);

        await operation.ExecuteAsync()
            .ConfigureAwait(false);
    }

    public async Task<TResult> CreateAndExecuteAsync<TOperation, TResult>(Action<TOperation> init = null)
        where TOperation : IOperation<TResult>
    {
        TOperation operation = operationFactory.Create<TOperation, TResult>();
        init?.Invoke(operation);

        return await operation.ExecuteAsync()
            .ConfigureAwait(false);
    }
}
