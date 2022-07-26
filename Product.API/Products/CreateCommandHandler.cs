﻿using AutoMapper;
using Commons.Core;
using MediatR;
using Product.API.Context;

namespace Product.API.Products;

public class CreateCommandHandler : IRequestHandler<CreateCommand, Result<Models.Product>>
{
    private readonly ProductContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandler(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Result<Models.Product>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Models.Product>(request.productForCreation);
        product.Id = Guid.NewGuid();

        _context.Products.Add(product);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return Result<Models.Product>.Failure("Failed to create product");
        return Result<Models.Product>.Success(product);
    }
}