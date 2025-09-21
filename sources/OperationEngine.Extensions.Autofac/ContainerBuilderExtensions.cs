using Autofac;

namespace DustInTheWInd.OperationEngine.Extensions.Autofac;

public static class ContainerBuilderExtensions
{
    public static void RegisterOperationEngine(this ContainerBuilder builder, Action<OperationEngineConfiguration> configBuilder)
    {
        OperationEngineConfiguration config = new();
        configBuilder?.Invoke(config);

        builder.RegisterOperations(config.OperationTypes);
        builder.RegisterOperationFactory(config.OperationFactoryType);
        builder.RegisterOperationManager();
    }

    private static void RegisterOperations(this ContainerBuilder builder, IEnumerable<Type> operationTypes)
    {
        foreach (Type operationType in operationTypes)
        {
            builder
                .RegisterType(operationType)
                .AsSelf()
                .InstancePerDependency();
        }
    }

    private static void RegisterOperationFactory(this ContainerBuilder builder, Type operationFactoryType)
    {
        operationFactoryType ??= typeof(AutofacOperationFactory);

        builder
            .RegisterType(operationFactoryType)
            .As<IOperationFactory>()
            .SingleInstance();
    }

    private static void RegisterOperationManager(this ContainerBuilder builder)
    {
        builder
            .RegisterType<OperationFactory>()
            .AsSelf()
            .SingleInstance();
    }
}
