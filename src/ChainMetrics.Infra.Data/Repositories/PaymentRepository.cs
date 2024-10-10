using AutoFilterer.Extensions;
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;

using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;
using ChainMetrics.Infra.Data.Context;
using ChainMetrics.Domain.DTOs;

namespace ChainMetrics.Infra.Data.Repositories;

public class PaymentRepository(AppDbContext context) : BaseRepository<Payment>(context), IPaymentRepository
{
    public Task<List<Payment>> Query(PaginationFilterBase filter)
    {
        return context.Payments
            .ApplyFilter(filter)
            .ToListAsync();
    }

    public Task<List<PerTypeDTO>> PerType()
    {
        return context.Payments
            .GroupBy(x => x.Type)
            .Select(x => new PerTypeDTO
            {
                Type = x.Key,
                Quantity = x.Count(),
                AverageInstallments = x.Average(x => x.Installments),
                TotalValue = x.Sum(x => x.Value)
            })
            .ToListAsync();
    }

    public async Task<List<PerInstallmentsDTO>> PerInstallments()
    {
        FormattableString query = $@"
            SELECT
                Payment.payment_installments AS QuantityInstallments,
                AVG((OrderProduct.price + OrderProduct.shipping_charges) / Payment.payment_installments) AS AverageInstallmentValue,
                SUM(OrderProduct.price) / COUNT(OrderProduct.order_id) AS AverageOrderValue,
                SUM(OrderProduct.price + OrderProduct.shipping_charges) / COUNT(OrderProduct.order_id) AS AverageOrderValueWithShipping
            FROM 
                df_Payments AS Payment
            INNER JOIN
                df_OrderItems AS OrderProduct ON Payment.order_id = OrderProduct.order_id
            WHERE
                Payment.payment_type = 'credit_card'
            GROUP BY 
                Payment.payment_installments
            HAVING
                Payment.payment_installments > 0
            ORDER BY
                Payment.payment_installments DESC";
        
        var result = await context.Database
            .SqlQuery<PerInstallmentsDTO>(query)
            .ToListAsync();
        
        return result;
    }
}
