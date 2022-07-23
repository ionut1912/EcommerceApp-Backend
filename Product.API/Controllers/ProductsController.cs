using Commons.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using Product.API.Products;

namespace Product.API.Controllers;

public class ProductsController : BaseApiController
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();
    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Product>>> GetProducts()
    {
        return HandleResult(await Mediator.Send(new ListCommand()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Product>> GetProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Models.Product>> UpdateProduct(Guid id, ProductForUpdate productForUpdate)
    {
        return HandleResult(await Mediator.Send(new EditComand { Id = id, productForUpdate = productForUpdate }));
    }

    // POST: api/DCandidate
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Models.Product>> AddProduct(ProductForCreation productForCreation)
    {
        return HandleResult(await Mediator.Send(new CreateCommand { productForCreation = productForCreation }));
    }

    // DELETE: api/DCandidate/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Models.Product>> DeleteProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryDelete { Id = id }));
    }
}