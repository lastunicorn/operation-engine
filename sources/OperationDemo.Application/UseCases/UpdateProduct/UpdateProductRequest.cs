using MediatR;

namespace OperationDemo.Application.UseCases.UpdateProduct;

public class UpdateProductRequest : IRequest
{
    public string Name { get; set; }

    public decimal Price { get; set; }
}
