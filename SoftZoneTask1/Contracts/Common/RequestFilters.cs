namespace SoftZoneTask1.Contracts.Common;

public record RequestFilters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 3;
    public string? SearchValue { get; set; }
}
