using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainMetrics.Domain.Entities;

[Table("df_Customers")]
public class Customer
{
    [Key]    
    [Column("customer_id")]
    public required string Id { get; set; }

    [Column("customer_zip_code_prefix")]
    public int ZipCode { get; set; }

    [Column("customer_city")]
    public required string City { get; set; }

    [Column("customer_state")]
    public required string State { get; set; }
}
