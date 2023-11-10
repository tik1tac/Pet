using System.Dynamic;

namespace Contract.IRepositoryModels;

public interface IProductsRepository : IRepositoryBase<ProductsEntity>
{
    Task<PageList<ProductsEntity>> GetProductsAsync(ProductsParametres param);

    Task<ProductsEntity> GetProductById(Guid id);

    Task UpdateProduct(ProductsEntity product);

    Task DeleteProduct(ProductsEntity product);

}