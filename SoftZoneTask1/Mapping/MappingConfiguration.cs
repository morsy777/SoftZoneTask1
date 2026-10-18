using Mapster;
using Microsoft.AspNetCore.Identity.Data;
using SoftZoneTask1.Contracts.Restaurant;
using SoftZoneTask1.Domain.Entities;

namespace SoftZoneTask1.Mapping;

public class MappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Restaurant, RestaurantResponse>()
            .Map(dest => dest.City, src => src.City.Name);
    }
}