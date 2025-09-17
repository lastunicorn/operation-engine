namespace OperationEngine;

public interface IOperationFactory
{
    public TOperation Create<TOperation>()
        where TOperation : IOperation;

    public TOperation Create<TOperation, TResult>()
        where TOperation : IOperation<TResult>;
}