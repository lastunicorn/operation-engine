using DustInTheWInd.OperationEngine;
using MediatR;
using OperationDemo.Application.Operations;

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
        await ExecuteHisOperation();
        await ExecuteAnotherOperation();

        Console.WriteLine("Product created successfully.");
    }

    private async Task ExecuteMyOperation(CreateProductRequest request)
    {
        await operationFactory.ExecuteAsync<MyOperation>(op =>
        {
            op.Name = request.Name;
            op.Age = 20;
        });
    }

    private async Task ExecuteHisOperation()
    {
        await operationFactory.ExecuteAsync<HisOperation>(op =>
        {
            op.Name = "Example2";
            op.Age = 21;
        });
    }

    private async Task ExecuteAnotherOperation()
    {
        int value = await operationFactory.ExecuteAsync<AnotherOperation, int>(op =>
        {
            op.Name = "Example3";
            op.Age = 22;
        });

        Console.WriteLine($"AnotherOperation returned value: {value}");
    }
}
