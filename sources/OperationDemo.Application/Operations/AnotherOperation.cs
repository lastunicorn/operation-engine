using DustInTheWInd.OperationEngine;

namespace OperationDemo.Application.Operations;

internal class AnotherOperation : IOperation<int>
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Task<int> ExecuteAsync()
    {
        Console.WriteLine($"Executing AnotherOperation. Name: {Name}; Age: {Age}");
        return Task.FromResult(100);
    }
}
