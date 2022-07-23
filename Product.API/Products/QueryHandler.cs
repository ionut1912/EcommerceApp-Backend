using Commons.Core;
using MediatR;
using Product.API.Context;

namespace Product.API.Products;

public class QueryHandler : IRequestHandler<QueryItem, Result<Models.Product>>
{
    private readonly ProductContext _context;

    public QueryHandler(ProductContext context)
    {
        _context = context;
    }

    public async Task<Result<Models.Product>> Handle(QueryItem request, CancellationToken cancellationToken)
    {
        var product = _context.Products.Find(request.Id);
        if (product == null) return Result<Models.Product>.Failure("Product not found");

        return Result<Models.Product>.Success(product);
    }
}