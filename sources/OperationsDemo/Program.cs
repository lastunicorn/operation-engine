using System.Reflection;
using Autofac;
using OperationEngine;
using OperationEngine.Extensions.Autofac;
using OperationsDemo.Operations;

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
        await operationManager.ExecuteAsync<AnotherOperation>(x =>
        {
            x.Name = "Example3";
            x.Age = 22;
        });
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
