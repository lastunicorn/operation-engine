using Autofac;
using DustInTheWInd.OperationEngine;

namespace DustInTheWInd.OperationEngine.Extensions.Autofac;

internal class AutofacOperationFactory : IOperationFactory
{
    private readonly ILifetimeScope lifetimeScope;

    public AutofacOperationFactory(ILifetimeScope lifetimeScope)
    {
        this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
    }

    public TOperation Create<TOperation>()
        where TOperation : IOperation
    {
        return lifetimeScope.Resolve<TOperation>();
    }

    public TOperation Create<TOperation, TResult>()
        where TOperation : IOperation<TResult>
    {
        return lifetimeScope.Resolve<TOperation>();
    }
}