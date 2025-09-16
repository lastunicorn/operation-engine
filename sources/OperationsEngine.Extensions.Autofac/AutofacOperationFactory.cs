using Autofac;

namespace OperationEngine.Extensions.Autofac;

internal class AutofacOperationFactory : IOperationFactory
{
    private readonly ILifetimeScope lifetimeScope;

    public AutofacOperationFactory(ILifetimeScope lifetimeScope)
    {
        this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
    }

    public T Create<T>()
        where T : IOperation
    {
        return lifetimeScope.Resolve<T>();
    }
}