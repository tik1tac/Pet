public class BonusEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BonusPercent { get; set; } = 0;
    public Guid IdProduct { get; set; }
    public ProductsEntity Product { get; set; }
}