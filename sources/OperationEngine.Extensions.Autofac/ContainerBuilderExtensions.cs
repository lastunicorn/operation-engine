using Autofac;

namespace OperationsEngine.Extensions.Autofac;

public static class ContainerBuilderExtensions
{
    public static void RegisterOperationEngine(this ContainerBuilder builder, Action<OperationEngineConfiguration> configBuilder)
    {
        OperationEngineConfiguration config = new();

        configBuilder?.Invoke(config);

        foreach (Type operationType in config.OperationTypes)
            builder
                .RegisterType(operationType)
                .AsSelf()
                .InstancePerDependency();

        Type operationFactoryType = config.OperationFactoryType ?? typeof(AutofacOperationFactory);

        builder
            .RegisterType(operationFactoryType)
            .As<IOperationFactory>()
            .SingleInstance();

        builder
            .RegisterType<OperationManager>()
            .AsSelf()
            .SingleInstance();
    }
}
