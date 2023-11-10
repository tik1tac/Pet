public class ImagesProductsEntity
{
    public Guid Id { get; set; }
    public byte[] Image { get; set; }
    public string NameImage { get; set; }
    public Guid IdProduct { get; set; }
    public ProductsEntity Product { get; set; }
}