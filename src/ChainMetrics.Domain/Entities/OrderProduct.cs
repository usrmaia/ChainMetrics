using System.ComponentModel.DataAnnotations.Schema;

namespace ChainMetrics.Domain.Entities;

[Table("df_OrderItems")]
public class OrderProduct
{
    [Column("order_id")]
    public required string OrderId { get; set; }
    public Order? Order { get; set; }

    [Column("product_id")]
    public required string ProductId { get; set; }
    public Product? Product { get; set; }

    [Column("seller_id")]
    public required string SellerId { get; set; }

    [Column("price")]
    public required decimal Price { get; set; }

    [Column("shipping_charges")]
    public required decimal ShippingCharges { get; set; }
}
