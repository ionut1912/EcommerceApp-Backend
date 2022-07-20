using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.API.Context;
using Product.API.Models;

namespace Product.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductContext _context;
    private readonly IMapper _mapper;

    public ProductsController(ProductContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Product>> GetProduct(Guid id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(Guid id, ProductForUpdate productForUpdate)
    {
        var product = _mapper.Map<Models.Product>(productForUpdate);
        product.Id = id;

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch 
        {
            throw;
        }
        return NoContent();
    }

    // POST: api/DCandidate
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Models.Product>> AddProduct(ProductForCreation productForCreation)
    {
        var product = _mapper.Map<Models.Product>(productForCreation);
        product.Id = Guid.NewGuid();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    // DELETE: api/DCandidate/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Models.Product>> DeleteProduct(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return product;
    }
}