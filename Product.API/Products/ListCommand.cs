using Commons.Core;
using MediatR;


namespace Product.API.Products;

public class ListCommand : IRequest<Result<List<Models.Product>>>
{
}