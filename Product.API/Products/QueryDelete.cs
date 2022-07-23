using Commons.Core;
using MediatR;


namespace Product.API.Products;

public class QueryDelete : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}