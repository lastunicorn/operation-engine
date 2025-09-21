
namespace DustInTheWInd.OperationEngine;

public class OperationBuilder<TOperation>
    where TOperation : IOperation
{
    private readonly TOperation operation;

    public OperationBuilder(TOperation operation)
    {
        this.operation = operation;
    }

    public OperationBuilder<TOperation> Initialise(Action<TOperation> init = null)
    {
        init?.Invoke(operation);
        return this;
    }

    public async Task ExecuteAsync()
    {
        await operation.ExecuteAsync()
            .ConfigureAwait(false);
    }
}
