using SoftZoneTask1.Abstraction;

namespace SoftZoneTask1.Errors;

public static class RestaurantErrors
{
    public static Error NotFound(int id) =>
        new("Restaurant.NotFound", $"Restaurant '{id}' was not found.", StatusCodes.Status404NotFound);

    public static Error CityNotFound(string city) =>
        new("Restaurant.CityNotFound", $"No restaurants found in '{city}'.", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Restaurant.InvalidSortColumn", "SortColumn must be one of: Name, City, Address.", StatusCodes.Status400BadRequest);
}