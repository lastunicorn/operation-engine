using MediatR;

namespace OperationDemo.Application.UseCases.CreateProduct;

public class CreateProductRequest : IRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
