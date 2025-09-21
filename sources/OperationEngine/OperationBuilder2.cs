namespace DustInTheWInd.OperationEngine;

public class OperationBuilder<TOperation, TResult>
    where TOperation : IOperation<TResult>
{
    private readonly TOperation operation;

    public OperationBuilder(TOperation operation)
    {
        this.operation = operation;
    }

    public OperationBuilder<TOperation, TResult> Initialise(Action<TOperation> init = null)
    {
        init?.Invoke(operation);
        return this;
    }

    public async Task<TResult> ExecuteAsync()
    {
        return await operation.ExecuteAsync()
            .ConfigureAwait(false);
    }
}