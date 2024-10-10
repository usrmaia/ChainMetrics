namespace ChainMetrics.Domain.DTOs;

public class PerTypeDTO
{
    public required string Type { get; set; }
    public int Quantity { get; set; }
    public double AverageInstallments { get; set; }
    public double TotalValue { get; set; }
}

public class PerInstallmentsDTO
{
    public int QuantityInstallments { get; set; }
    public double AverageInstallmentValue { get; set; }
    public double AverageOrderValue { get; set; }
    public double AverageOrderValueWithShipping { get; set; }
}