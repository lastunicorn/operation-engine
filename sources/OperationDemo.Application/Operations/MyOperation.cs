using DustInTheWInd.OperationEngine;

namespace OperationDemo.Application.Operations;

internal class MyOperation : IOperation
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Task ExecuteAsync()
    {
        Console.WriteLine($"Executing MyOperation. Name: {Name}; Age: {Age}");
        return Task.CompletedTask;
    }
}
