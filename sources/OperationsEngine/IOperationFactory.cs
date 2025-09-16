namespace OperationEngine;

public interface IOperationFactory
{
    T Create<T>()
        where T : IOperation;
}