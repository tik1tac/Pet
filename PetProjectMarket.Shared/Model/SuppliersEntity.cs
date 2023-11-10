public class SuppliersEntity
{
    public Guid Id { get; set; }
    public string NameSuppliers { get; set; }
    public string NameCompany { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public List<ProductsEntity> Products { get; set; }
}