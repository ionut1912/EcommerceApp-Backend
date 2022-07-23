using MediatR;
using Product.API.Core;

namespace Product.API.Products;

public class QueryItem : IRequest<Result<Models.Product>>
{
    public Guid Id { get; set; }
}