using System.Diagnostics;
using System.Reflection;
using Autofac;
using OperationsDemo.Operations;
using OperationsEngine;
using OperationsEngine.Extensions.Autofac;

namespace OperationsDemo;

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
        await operationManager.ExecuteAsync<MyOperation>(x =>
        {
            x.Name = "Example1";
            x.Age = 20;
        });
    }

    private static async Task ExecuteHisOperation(OperationManager operationManager)
    {
        await operationManager.ExecuteAsync<HisOperation>(x =>
        {
            x.Name = "Example2";
            x.Age = 21;
        });
    }

    private static async Task ExecuteAnotherOperation(OperationManager operationManager)
    {
        int value = await operationManager.ExecuteAsync<AnotherOperation, int>(x =>
        {
            x.Name = "Example3";
            x.Age = 22;
        });

        Console.WriteLine($"AnotherOperation returned value: {value}");
    }

    private static IContainer BuildDependencyContainer()
    {
        ContainerBuilder builder = new();

        Stopwatch stopwatch = Stopwatch.StartNew();
        builder.RegisterOperationEngine(config =>
        {
            config.AddOperationsFromAssembly(Assembly.GetExecutingAssembly());
        });
        stopwatch.Stop();
        Console.WriteLine($"Registered operation engine in {stopwatch.ElapsedMilliseconds}ms");

        return builder.Build();
    }
}
