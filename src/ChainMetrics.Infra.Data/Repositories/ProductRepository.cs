using AutoFilterer.Extensions;
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;

using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;
using ChainMetrics.Infra.Data.Context;
using ChainMetrics.Domain.DTOs;

namespace ChainMetrics.Infra.Data.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public Task<List<Product>> Query(PaginationFilterBase filter)
    {
        return context.Products
            .ApplyFilter(filter)
            .ToListAsync();
    }

    public async Task<List<PerCategoryDTO>> PerCategory()
    {
        FormattableString query = $@"
            SELECT
                COALESCE(Product.product_category_name, 'no_ategory') AS Category,
                COUNT(Product.product_id) AS QuantityProducts,
                SUM(OrderProduct.price) AS TotalOrderPrice,
                SUM(OrderProduct.price - OrderProduct.shipping_charges) AS Profit
            FROM
                df_Products Product
            INNER JOIN
                df_OrderItems OrderProduct ON Product.product_id = OrderProduct.product_id
            GROUP BY
                Product.product_category_name
            ORDER BY TotalOrderPrice DESC";

        var result = await context.Database
            .SqlQuery<PerCategoryDTO>(query)
            .ToListAsync();

        return result;
    }
}
