using DustInTheWInd.OperationEngine;

namespace OperationDemo.Application.Operations;

internal class AnotherOperation : IOperation<int>
{
    private readonly Random random = new();

    public string Name { get; set; }

    public decimal Price { get; set; }

    public Task<int> ExecuteAsync()
    {
        Console.WriteLine($"Executing AnotherOperation. Name: {Name}; Price: {Price}");
        return Task.FromResult(random.Next(100));
    }
}
