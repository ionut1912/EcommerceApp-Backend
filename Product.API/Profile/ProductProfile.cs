using Product.API.Models;

namespace Product.API.Profile;

public class ProductProfile : AutoMapper.Profile
{
    public ProductProfile()
    {
        CreateMap<Models.Product, ProductForCreation>().ReverseMap();
        CreateMap<Models.Product, ProductForUpdate>().ReverseMap();
    }
}