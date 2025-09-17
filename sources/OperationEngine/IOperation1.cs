namespace OperationEngine;

public interface IOperation<T>
{
    Task<T> ExecuteAsync();
}