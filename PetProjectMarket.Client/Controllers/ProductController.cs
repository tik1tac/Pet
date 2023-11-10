using Microsoft.AspNetCore.Mvc;
using PetProjectMarket.Client.Services.Product;
using PetProjectMarket.Shared.ModelDTO.Product;

namespace PetProjectMarket.Client.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientServiceProductImplementaion productClient;
		public ProductController(IHttpClientServiceProductImplementaion _productClient)
		{
			productClient = _productClient;
		}
		public IActionResult CreateProduct() => View();

		public async Task<IActionResult> CreateProduct(CreateProductDTO productCreate)
		{
			if (!ModelState.IsValid || productCreate is null)
				return View(productCreate);

			await productClient.CreateProduct(productCreate);

			return View();
		}
		[HttpGet]
		public IActionResult UpdateProduct() => View();
		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProducts productUpdate)
		{
			if (!ModelState.IsValid || productUpdate is null)
				return View(productUpdate);

			await productClient.UpdateProduct(productUpdate);

			return View();
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(DeleteProduct productDelete)
		{
			await productClient.DeleteProduct(productDelete);

			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetProduct(ProductsParametres paramProd)
		{
			var products = await productClient.GetProduct(paramProd);

			return View(products);
		}
	}
}
