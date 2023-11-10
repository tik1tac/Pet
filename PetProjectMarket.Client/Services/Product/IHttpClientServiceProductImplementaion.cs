using PetProjectMarket.Shared.Helpers;
using PetProjectMarket.Shared.ModelDTO.Product;

namespace PetProjectMarket.Client.Services.Product
{
	public interface IHttpClientServiceProductImplementaion
	{
		Task<PagingResponse<ProductsEntity>> GetProduct(ProductsParametres parametr);
		Task CreateProduct(CreateProductDTO product);
		Task UpdateProduct(UpdateProducts product);
		Task DeleteProduct(DeleteProduct product);
	}
}
