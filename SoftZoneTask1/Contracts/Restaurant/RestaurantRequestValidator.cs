using FluentValidation;

namespace SoftZoneTask1.Contracts.Restaurant;

public class RestaurantRequestValidator : AbstractValidator<RestaurantRequest>
{
    public RestaurantRequestValidator()
    {
        RuleFor(x => x.City)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.City));
    }
}
