public class ProductsParametres : QueryStringParametres
{
    public ProductsParametres()
    {
        OrderBy = "Name";
    }
    public uint PriceMin { get; set; }
    public uint PriceMax { get; set; }

    public bool ValidPrice => PriceMin <= PriceMax;

    public string NameProduct { get; set; }
}