using MediatR;
using Product.API.Core;

namespace Product.API.Products;

public class ListCommand : IRequest<Result<List<Models.Product>>>
{
}