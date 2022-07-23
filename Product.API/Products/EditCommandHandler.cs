using AutoMapper;
using Commons.Core;
using MediatR;
using Product.API.Context;


namespace Product.API.Products;

public class EditCommandHandler : IRequestHandler<EditComand, Result<Unit>>
{
    private readonly ProductContext _context;
    private readonly IMapper _mapper;

    public EditCommandHandler(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(EditComand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null) return null;
        _mapper.Map(request.productForUpdate, product);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return Result<Unit>.Failure("Failed to update product");
        return Result<Unit>.Success(Unit.Value);
    }
}