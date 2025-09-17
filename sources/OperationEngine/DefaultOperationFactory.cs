namespace OperationsEngine;

public class DefaultOperationFactory : IOperationFactory
{
    public TOperation Create<TOperation>()
        where TOperation : IOperation
    {
        return Activator.CreateInstance<TOperation>();
    }

    public TOperation Create<TOperation, TResult>()
        where TOperation : IOperation<TResult>
    {
        return Activator.CreateInstance<TOperation>();
    }
}
