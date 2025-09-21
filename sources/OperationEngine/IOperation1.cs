namespace DustInTheWInd.OperationEngine;

public interface IOperation<TResult>
{
    Task<TResult> ExecuteAsync();
}