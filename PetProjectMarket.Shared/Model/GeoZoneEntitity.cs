public class GeoZoneEntitity
{
    public int Id { get; set; }
    public string NumberCountry { get; set; }
    public string NameCountry { get; set; }
    public List<UserEntity> User { get; set; }
}