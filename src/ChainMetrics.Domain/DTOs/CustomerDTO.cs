namespace ChainMetrics.Domain.DTOs;

public class PerCustomerDTO
{
    public required string CustomerId { get; set; }
    public int TotalOrders { get; set; }
    public int TotalPaymentValue { get; set; }
    public int TotalOrderPrice { get; set; }
    public int TotalOrderShipping { get; set; }
}

public class PerStateDTO
{
    public required string State { get; set; }
    public int QuantityOrders { get; set; }
    public int TotalPaymentValue { get; set; }
}

public class PerCityDTO
{
    public required string City { get; set; }
    public required string State { get; set; }
    public int QuantityPurchase { get; set; }
    public int TotalPaymentValue { get; set; }
}
