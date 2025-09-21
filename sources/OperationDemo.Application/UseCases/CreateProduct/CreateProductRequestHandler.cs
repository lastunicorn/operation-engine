using DustInTheWInd.OperationEngine;
using MediatR;
using OperationDemo.Application.SubUseCases;

namespace OperationDemo.Application.UseCases.CreateProduct;

internal class CreateProductRequestHandler : IRequestHandler<CreateProductRequest>
{
    private readonly OperationFactory operationFactory;

    public CreateProductRequestHandler(OperationFactory operationFactory)
    {
        this.operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
    }

    public async Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        await ExecuteMyOperation(request);
        await ExecuteHisOperation(request);
        await ExecuteAnotherOperation(request);

        Console.WriteLine("Product created successfully.");
    }

    private async Task ExecuteMyOperation(CreateProductRequest request)
    {
        await operationFactory.Create<MyOperation>()
            .Initialise(op =>
            {
                op.Name = request.Name;
                op.Price = request.Price;
            })
            .ExecuteAsync();
    }

    private async Task ExecuteHisOperation(CreateProductRequest request)
    {
        await operationFactory.Create<HisOperation>()
            .Initialise(op =>
            {
                op.Name = request.Name;
                op.Price = request.Price;
            })
            .ExecuteAsync();
    }

    private async Task ExecuteAnotherOperation(CreateProductRequest request)
    {
        int value = await operationFactory.Create<AnotherOperation, int>()
            .Initialise(op =>
            {
                op.Name = request.Name;
                op.Price = request.Price;
            })
            .ExecuteAsync();

        Console.WriteLine($"AnotherOperation returned value: {value}");
    }
}
