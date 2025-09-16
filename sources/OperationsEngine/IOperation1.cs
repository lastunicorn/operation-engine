namespace OperationsEngine;

public interface IOperation<T>
{
    Task<T> ExecuteAsync();
}