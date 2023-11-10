using PetProjectMarket.Client.Clients;
using PetProjectMarket.Shared.Helpers;
using PetProjectMarket.Shared.ModelDTO.Product;

namespace PetProjectMarket.Client.Services.Product
{
	//TODO dopilit kontroller ctobu bral IHTTP
	public class HttpClientFactoryServiceProduct : IHttpClientServiceProductImplementaion
	{
		private readonly ProductscClient productClient;

		public HttpClientFactoryServiceProduct(ProductscClient productClient)
		{
			this.productClient = productClient;
		}

		public async Task<PagingResponse<ProductsEntity>> GetProduct(ProductsParametres parametr) => await productClient.GetProducts(parametr);

		public async Task CreateProduct(CreateProductDTO product) => await productClient.CreateProducts(product);
		public async Task UpdateProduct(UpdateProducts product) => await productClient.UpdateProduct(product);

		public async Task DeleteProduct(DeleteProduct product) => await productClient.DeleteProduct(product);
	}
}
