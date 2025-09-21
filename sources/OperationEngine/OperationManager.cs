namespace DustInTheWInd.OperationEngine;

public class OperationManager
{
    private readonly IOperationFactory operationFactory;

    public OperationManager(IOperationFactory operationFactory)
    {
        this.operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
    }

    public OperationBuilder<TOperation> Build<TOperation>()
        where TOperation : IOperation
    {
        TOperation operation = operationFactory.Create<TOperation>();
        return new OperationBuilder<TOperation>(operation);
    }

    public OperationBuilder<TOperation, TResult> Build<TOperation, TResult>()
        where TOperation : IOperation<TResult>
    {
        TOperation operation = operationFactory.Create<TOperation, TResult>();
        return new OperationBuilder<TOperation, TResult>(operation);
    }

    public async Task CreateAndExecuteAsync<TOperation>(Action<TOperation> init = null)
        where TOperation : IOperation
    {
        TOperation operation = operationFactory.Create<TOperation>();
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
