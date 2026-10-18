using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftZoneTask1.Abstraction;
using SoftZoneTask1.Contracts.Common;
using SoftZoneTask1.Service.Restaurant;

namespace SoftZoneTask1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RestaurantsController(IRestaurantService restaurantService) : ControllerBase
{
    private readonly IRestaurantService _restaurantService = restaurantService;

    [HttpGet("city/{city=Cairo}")]
    public async Task<IActionResult> GetAll([FromRoute] string city, [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken)
    {
        var result = await _restaurantService.GetAllAsync(city, filters, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
