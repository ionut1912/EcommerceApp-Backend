using Commons.Core;
using MediatR;

using Product.API.Models;

namespace Product.API.Products;

public class CreateCommand : IRequest<Result<Models.Product>>
{
    public ProductForCreation productForCreation { get; set; }
}