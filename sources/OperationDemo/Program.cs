using System.Reflection;
using Autofac;
using DustInTheWInd.OperationDemo.Operations;
using DustInTheWInd.OperationEngine;
using DustInTheWInd.OperationEngine.Extensions.Autofac;

namespace DustInTheWInd.OperationDemo;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        IContainer container = BuildDependencyContainer();

        OperationManager operationManager = container.Resolve<OperationManager>();

        await ExecuteMyOperation(operationManager);
        await ExecuteHisOperation(operationManager);
        await ExecuteAnotherOperation(operationManager);
    }

    private static async Task ExecuteMyOperation(OperationManager operationManager)
    {
        await operationManager.ExecuteAsync<MyOperation>(op =>
        {
            op.Name = "Example1";
            op.Age = 20;
        });
    }

    private static async Task ExecuteHisOperation(OperationManager operationManager)
    {
        await operationManager.ExecuteAsync<HisOperation>(op =>
        {
            op.Name = "Example2";
            op.Age = 21;
        });
    }

    private static async Task ExecuteAnotherOperation(OperationManager operationManager)
    {
        int value = await operationManager.ExecuteAsync<AnotherOperation, int>(op =>
        {
            op.Name = "Example3";
            op.Age = 22;
        });

        Console.WriteLine($"AnotherOperation returned value: {value}");
    }

    private static IContainer BuildDependencyContainer()
    {
        ContainerBuilder builder = new();

        builder.RegisterOperationEngine(config =>
        {
            config.AddOperationsFromAssembly(Assembly.GetExecutingAssembly());
        });

        return builder.Build();
    }
}
