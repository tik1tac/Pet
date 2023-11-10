public class Basket
{
    public Guid IdOrder { get; set; }
    public OrdersEntity Order { get; set; }
    public Guid IdProduct { get; set; }
    public ProductsEntity Products { get; set; }
}