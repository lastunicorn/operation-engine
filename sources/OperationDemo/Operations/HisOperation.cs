using DustInTheWInd.OperationEngine;

namespace DustInTheWInd.OperationDemo.Operations;

internal class HisOperation : IOperation
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Task ExecuteAsync()
    {
        Console.WriteLine($"Executing HisOperation. Name: {Name}; Age: {Age}");
        return Task.CompletedTask;
    }
}
