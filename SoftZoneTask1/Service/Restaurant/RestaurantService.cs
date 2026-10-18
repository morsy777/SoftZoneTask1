using Mapster;
using Microsoft.EntityFrameworkCore;
using SoftZoneTask1.Abstraction;
using SoftZoneTask1.Contracts.Common;
using SoftZoneTask1.Contracts.Restaurant;
using SoftZoneTask1.Errors;
using SoftZoneTask1.Persistence;

namespace SoftZoneTask1.Service.Restaurant;

public class RestaurantService(ApplicationDbContext context) : IRestaurantService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<PaginatedList<RestaurantResponse>>> GetAllAsync(
        string city, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        city = city.Trim();

        var cityExists = await _context.Restaurants.AnyAsync(x => x.City.Name == city, cancellationToken);

        if (!cityExists)
            return Result.Failure<PaginatedList<RestaurantResponse>>(RestaurantErrors.CityNotFound(city));

        var query = _context.Restaurants
            .Where(x => x.City.Name == city);

        if (!string.IsNullOrWhiteSpace(filters.SearchValue))
        {
            var name = filters.SearchValue.Trim();
            query = query.Where(x => x.Name.Contains(name));
        }

        var source = query
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Id)   
            .ProjectToType<RestaurantResponse>()
            .AsNoTracking();

        var restaurants = await PaginatedList<RestaurantResponse>.CreateAsync(
            source, 
            filters.PageNumber, 
            filters.PageSize, 
            cancellationToken);

        return Result.Success(restaurants);
    }
    public Task<bool> ExistsAsync(int restaurantId, CancellationToken cancellationToken = default)
    {
        return _context.Restaurants
            .AsNoTracking()
            .AnyAsync(x => x.Id == restaurantId, cancellationToken);
    }
    
}
