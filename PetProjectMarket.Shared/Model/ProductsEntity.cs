public class ProductsEntity
{
    public Guid Id { get; set; }
    public string NameProduct { get; set; }
    public int PriceProduct { get; set; }
    public int WeightProduct { get; set; }
    public string BarcodeProduct { get; set; }
    public string Compound { get; set; }
    public StatusProduct Status { get; set; }
    public int Quantity { get; set; }
    public string Option { get; set; }
    public Guid IdSupplier { get; set; }
    public SuppliersEntity Supplier { get; set; } = new();
    public List<ImagesProductsEntity> Images { get; set; }
    public List<CategoryProductsEntity> CategoryProducts { get; set; }
    public List<Basket> Basket { get; set; } = new List<Basket>();
    public List<OrdersEntity> Orders { get; set; } = new List<OrdersEntity>();
    public List<BonusEntity> Bonus { get; set; } = new List<BonusEntity>();
}