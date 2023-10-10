using Application.Product.Enums;

namespace Application.Product.Queries;

public sealed record SearchProductsDTO
{
    public string? Name { get; set; }

    public string? Category { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }

    public SortOrder SortOrder { get; set; }

}
