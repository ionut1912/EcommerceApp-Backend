using Commons.Core;
using MediatR;


namespace Product.API.Products;

public class QueryItem : IRequest<Result<Models.Product>>
{
    public Guid Id { get; set; }
}