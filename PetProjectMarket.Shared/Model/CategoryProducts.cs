public class CategoryProductsEntity
{
    public int Id { get; set; }
    public string NameCategory { get; set; }
    public string DescriptionCategory { get; set; } = string.Empty;
    public byte[] Image { get; set; }
    public int QuantityProduct { get; set; }
    public Guid IdProduct { get; set; }
    public ProductsEntity ProductsEntity { get; set; }
}