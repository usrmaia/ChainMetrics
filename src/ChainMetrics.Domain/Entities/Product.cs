using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainMetrics.Domain.Entities;

[Table("df_Products")]
public class Product
{
    [Key]
    [Column("product_id")]
    public required string Id { get; set; }

    [Column("product_category_name")]
    public required string Category { get; set; }

    [Column("product_weight_g")]
    public double Weight { get; set; }

    [Column("product_length_cm")]
    public double Length { get; set; }

    [Column("product_height_cm")]
    public double Height { get; set; }

    [Column("product_width_cm")]
    public double Width { get; set; }
}
