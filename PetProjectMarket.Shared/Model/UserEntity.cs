using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public decimal Wallet { get; set; } = 0;
    public string IpAddress { get; set; }
    public StateUser State { get; set; }
    public int IdGeoZOne { get; set; }
    public GeoZoneEntitity Language { get; set; } = new();
    public List<OrdersEntity> Orders { get; set; } = new List<OrdersEntity>();
}