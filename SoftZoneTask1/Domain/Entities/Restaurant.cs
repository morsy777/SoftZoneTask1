namespace SoftZoneTask1.Domain.Entities;

public class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    public int CityId { get; set; }

    public City City { get; set; } = null!;

    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}