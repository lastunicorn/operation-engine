using DustInTheWInd.OperationEngine;
using MediatR;
using OperationDemo.Application.Operations;

namespace OperationDemo.Application.UseCases.UpdateProduct;

internal class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest>
{
    private readonly OperationFactory operationFactory;

    public UpdateProductRequestHandler(OperationFactory operationFactory)
    {
        this.operationFactory = operationFactory;
    }

    public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        await ExecuteMyOperation(request);
        await ExecuteHisOperation(request);
        await ExecuteAnotherOperation(request);

        Console.WriteLine("Product updated successfully.");
    }

    private async Task ExecuteMyOperation(UpdateProductRequest request)
    {
        await operationFactory.CreateAndExecuteAsync<MyOperation>(op =>
        {
            op.Name = request.Name;
            op.Price = request.Price;
        });
    }

    private async Task ExecuteHisOperation(UpdateProductRequest request)
    {
        await operationFactory.CreateAndExecuteAsync<HisOperation>(op =>
        {
            op.Name = request.Name;
            op.Price = request.Price;
        });
    }

    private async Task ExecuteAnotherOperation(UpdateProductRequest request)
    {
        int value = await operationFactory.CreateAndExecuteAsync<AnotherOperation, int>(op =>
        {
            op.Name = request.Name;
            op.Price = request.Price;
        });

        Console.WriteLine($"AnotherOperation returned value: {value}");
    }
}