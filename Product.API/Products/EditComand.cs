﻿using MediatR;
using Product.API.Core;
using Product.API.Models;

namespace Product.API.Products;

public class EditComand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
    public ProductForUpdate productForUpdate { get; set; }
}