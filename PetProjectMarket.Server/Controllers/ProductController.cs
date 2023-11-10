using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetProjectMarket.Shared.ModelDTO.Product;
using Serilog;

namespace PetProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryWrapper wrapper;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public ProductController(IRepositoryWrapper _wrapper, IMapper _mapper, IMediator _mediator)
        => (wrapper, mapper, mediator) = (_wrapper, _mapper, _mediator);
        [HttpGet("/GetProduct")]
        public async Task<IActionResult> Get([FromQuery] ProductsParametres parametrQuery)
        {
            var products = await wrapper.Product.GetProductsAsync(parametrQuery);

            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(products.Metadata));
            Log.Information("GetProducts from BD");

            return Ok(products);
        }
        [HttpPost("/CreateProduct")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO product)
        {
            if (!ModelState.IsValid && product is not null)
                return BadRequest(product);

            var resultProd = mapper.Map<ProductsEntity>(product);
            await wrapper.Product.AddAsync(resultProd);
            await wrapper.SaveAsync();
            Log.Information("CreateProduct");

            return Created("", resultProd);
        }
        [HttpPut("{id}", Name = "DeleteProduct")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(Guid Id, [FromBody] UpdateProducts product)
        {
            if (product is not null)
                return BadRequest("Product is empty");

            if (!ModelState.IsValid)
                return BadRequest(product);

            var prod = await wrapper.Product.GetProductById(Id);
            if (prod is null)
                return NotFound();

            mapper.Map(product, prod);

            await wrapper.Product.Update(prod);
            await wrapper.SaveAsync();
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteProduct")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await wrapper.Product.GetProductById(id);
            if (product is null)
                return NotFound();

            await wrapper.Product.DeleteProduct(product);
            await wrapper.SaveAsync();

            return NoContent();
        }
    }
}
