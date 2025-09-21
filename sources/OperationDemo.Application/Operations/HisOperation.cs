using DustInTheWInd.OperationEngine;

namespace OperationDemo.Application.Operations;

internal class HisOperation : IOperation
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Task ExecuteAsync()
    {
        Console.WriteLine($"Executing HisOperation. Name: {Name}; Price: {Price}");
        return Task.CompletedTask;
    }
}
