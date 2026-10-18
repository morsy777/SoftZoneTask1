namespace SoftZoneTask1.Domain.Entities;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}