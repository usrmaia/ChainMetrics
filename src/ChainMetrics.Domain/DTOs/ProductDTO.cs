namespace ChainMetrics.Domain.DTOs;

public class PerCategoryDTO
{
    public required string Category { get; set; }
    public int QuantityProducts { get; set; }
    public double TotalOrderPrice { get; set; }
    public double Profit { get; set; }
}