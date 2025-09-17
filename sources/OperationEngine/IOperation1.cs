namespace DustInTheWInd.OperationEngine;

public interface IOperation<T>
{
    Task<T> ExecuteAsync();
}