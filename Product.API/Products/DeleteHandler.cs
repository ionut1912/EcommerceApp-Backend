using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Context;
using Product.API.Core;

namespace Product.API.Products;

public class DeleteHandler:IRequestHandler<QueryDelete,Result<Unit>>
{
    private readonly ProductContext _context;
    public DeleteHandler(ProductContext context)
    {
        _context = context;

    }
    public async Task<Result<Unit>> Handle(QueryDelete request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null)
        {
            return null;

        }
        _context.Remove(product);
        var result=await _context.SaveChangesAsync()>0;
        if (!result) return Result<Unit>.Failure("Failed to delete product");
        return Result<Unit>.Success(Unit.Value);
    }
}