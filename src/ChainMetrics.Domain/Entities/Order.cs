using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainMetrics.Domain.Entities;

[Table("df_Orders")]
public class Order
{
    [Key]
    [Column("order_id")]
    public required string Id { get; set; }

    [Column("customer_id")]
    public required string CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [Column("order_status")]
    public required string Status { get; set; }

    [Column("order_purchase_timestamp")]
    public DateTime PurchaseTimestamp { get; set; }

    [Column("order_approved_at")]
    public DateTime? ApprovedAt { get; set; }

    [Column("order_delivered_timestamp")]
    public DateTime? DeliveredTimestamp { get; set; }

    [Column("order_estimated_delivery_date")]
    public DateOnly? EstimatedDeliveryDate { get; set; }
}
