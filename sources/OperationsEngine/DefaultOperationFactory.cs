namespace OperationEngine;

public class DefaultOperationFactory : IOperationFactory
{
    public T Create<T>()
        where T : IOperation
    {
        T operation = Activator.CreateInstance<T>();
        return operation;
    }
}
