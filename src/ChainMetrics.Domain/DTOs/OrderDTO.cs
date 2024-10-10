namespace ChainMetrics.Domain.DTOs;

public class PerStatusDTO
{
    public required string Status { get; set; }
    public required int Quantity { get; set; }
    public double TotalDeliveryHours { get; set; }
}

public class PerPurchase
{
    public DateOnly PurchaseDate { get; set; }
    public required int Quantity { get; set; }
}