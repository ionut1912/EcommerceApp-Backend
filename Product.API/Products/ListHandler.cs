using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Context;
using Product.API.Core;

namespace Product.API.Products;

public class ListHandler : IRequestHandler<ListCommand,Result<List<Models.Product>>>
{
    private readonly ProductContext _context;

    public ListHandler(ProductContext context)
    {
        _context = context;
    }


    public async  Task<Result<List<Models.Product>>> Handle(ListCommand request, CancellationToken cancellationToken)
    {
        return Result<List<Models.Product>>.Success(await _context.Products.ToListAsync());
    }
}