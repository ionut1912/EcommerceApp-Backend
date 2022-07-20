using Microsoft.EntityFrameworkCore;
namespace Product.API.Context;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }
    public DbSet<Models.Product> Products { get; set; }
}