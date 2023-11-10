using Contract.IRepositoryModels;

using PetProjectMarket.Shared.Helpers;

using Repository;

using System.Dynamic;

public class ProductsRepository : RepositoryBase<ProductsEntity>, IProductsRepository
{
    ISortHelpers<ProductsEntity> sortproduct;
    public ProductsRepository(AplicationContext _context, ISortHelpers<ProductsEntity> _prodsort) : base(_context)
    {
        sortproduct = _prodsort;
    }

    public async Task DeleteProduct(ProductsEntity product) => await DeleteProduct(product);

    public async Task<ProductsEntity> GetProductById(Guid id) => (await GetByCondition(p => p.Id.Equals(id))).FirstOrDefault();

    public async Task UpdateProduct(ProductsEntity product) => await Update(product);

    public async Task<PageList<ProductsEntity>> GetProductsAsync(ProductsParametres param)
    {
        var products = (await GetByCondition(p => p.PriceProduct >= param.PriceMin && p.PriceProduct <= param.PriceMax)).OrderBy(on => on.NameProduct).AsQueryable();
        SearchProduct(ref products, param.NameProduct);
        sortproduct.ApplySort(ref products, param.OrderBy);

        return PageList<ProductsEntity>.ToPageList(products.ToList(), param.PageNumber, param.PageSize);
    }

    private void SearchProduct(ref IQueryable<ProductsEntity> products, string nameProduct)
    {
        if (!products.Any() && String.IsNullOrWhiteSpace(nameProduct))
            return;

        products.Where(p => p.NameProduct.ToLower().Contains(nameProduct.Trim().ToLower()));
    }
}