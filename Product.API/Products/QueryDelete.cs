using MediatR;
using Product.API.Core;

namespace Product.API.Products;

public class QueryDelete : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}