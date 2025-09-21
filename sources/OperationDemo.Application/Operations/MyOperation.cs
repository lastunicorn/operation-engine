using DustInTheWInd.OperationEngine;

namespace OperationDemo.Application.Operations;

internal class MyOperation : IOperation
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Task ExecuteAsync()
    {
        Console.WriteLine($"Executing MyOperation. Name: {Name}; Price: {Price}");
        return Task.CompletedTask;
    }
}
