public class OrdersEntity
{
    public Guid Id { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public StatusOrder Status { get; set; } = StatusOrder.NoOrder;
    public string NameAndNumber { get; set; }
    public DateTime DateTimeDelivery { get; set; }
    public DeliveryMethod Delivery { get; set; }
    public PayMethod PayMethod { get; set; } = PayMethod.Cash;
    public string Comment { get; set; }
    public string IdUser { get; set; }
    public UserEntity User { get; set; }
    public List<Basket> Basket { get; set; } = new List<Basket>();
    public List<ProductsEntity> Product { get; set; } = new List<ProductsEntity>();
}