using SoftZoneTask1.Abstraction;
using SoftZoneTask1.Contracts.Common;
using SoftZoneTask1.Contracts.Restaurant;

namespace SoftZoneTask1.Service.Restaurant;

public interface IRestaurantService
{
    Task<Result<PaginatedList<RestaurantResponse>>> GetAllAsync(string city, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(int restaurantId, CancellationToken cancellationToken = default);
}
