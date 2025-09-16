using OperationEngine;

namespace OperationsDemo.Operations;

internal class AnotherOperation : IOperation
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Task ExecuteAsync()
    {
        Console.WriteLine($"Executing AnotherOperation. Name: {Name}; Age: {Age}");
        return Task.CompletedTask;
    }
}
