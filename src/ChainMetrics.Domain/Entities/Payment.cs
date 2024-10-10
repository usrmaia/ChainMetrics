using System.ComponentModel.DataAnnotations.Schema;

namespace ChainMetrics.Domain.Entities;

[Table("df_Payments")]
public class Payment
{
    [Column("order_id")]
    public required string OrderId { get; set; }

    [Column("payment_sequential")]
    public required int Sequential { get; set; }

    [Column("payment_type")]
    public required string Type { get; set; }

    [Column("payment_installments")]
    public required int Installments { get; set; }

    [Column("payment_value")]
    public required double Value { get; set; }
}
