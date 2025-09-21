using System.Reflection;
using Autofac;
using DustInTheWInd.OperationEngine.Extensions.Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using OperationDemo.Application.UseCases.CreateProduct;
using OperationDemo.Application.UseCases.UpdateProduct;

namespace DustInTheWInd.OperationDemo;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        IContainer container = BuildDependencyContainer();

        IMediator mediator = container.Resolve<IMediator>();

        await ExecuteCreateProduct(mediator);
        Console.WriteLine();
        await ExecuteUpdateProduct(mediator);
    }

    private static async Task ExecuteCreateProduct(IMediator mediator)
    {
        CreateProductRequest request = new()
        {
            Name = "Sample Product",
            Price = 99.99m
        };
        await mediator.Send(request);
    }

    private static async Task ExecuteUpdateProduct(IMediator mediator)
    {
        UpdateProductRequest request = new()
        {
            Name = "Updated Product",
            Price = 5.99m
        };
        await mediator.Send(request);
    }

    private static IContainer BuildDependencyContainer()
    {
        ContainerBuilder builder = new();

        Assembly useCaseAssembly = typeof(CreateProductRequest).Assembly;

        builder.RegisterOperationEngine(config =>
        {
            config.AddOperationsFromAssembly(useCaseAssembly);
        });

        builder.RegisterMediatR(MediatRConfigurationBuilder.Create(useCaseAssembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build());

        return builder.Build();
    }
}
