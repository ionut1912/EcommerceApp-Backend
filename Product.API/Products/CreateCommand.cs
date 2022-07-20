
using MediatR;
using Product.API.Core;
using Product.API.Models;

namespace Product.API.Products;

    public class CreateCommand :IRequest<Result<Unit>>
    {
        public ProductForCreation productForCreation { get; set; }
    }
