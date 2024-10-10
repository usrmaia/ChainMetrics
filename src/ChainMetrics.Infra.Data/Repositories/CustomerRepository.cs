using AutoFilterer.Extensions;
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;
using ChainMetrics.Infra.Data.Context;
using ChainMetrics.Domain.DTOs;
using System.Runtime.CompilerServices;

namespace ChainMetrics.Infra.Data.Repositories;

public class CustomerRepository(AppDbContext context) : BaseRepository<Customer>(context), ICustomerRepository
{
    public Task<List<Customer>> Query(PaginationFilterBase filter)
    {
        return context.Customers.ApplyFilter(filter).ToListAsync();
    }

    public async Task<List<PerCustomerDTO>> TopExpensiveCustomers(int top)
    {
        FormattableString query = $@"
            SELECT
                Customer.customer_id AS CustomerId,
                COUNT(_Order.customer_id) AS TotalOrders,
                SUM(Payment.payment_value / Payment.payment_installments * Payment.payment_sequential) AS TotalPaymentValue,
                SUM(OrderProduct.price) AS TotalOrderPrice,
                SUM(OrderProduct.shipping_charges) AS TotalOrderShipping
            FROM
                df_Customers Customer
            INNER JOIN
                df_Orders _Order ON Customer.customer_id = _Order.customer_id
            INNER JOIN
                df_OrderItems OrderProduct ON _Order.order_id = OrderProduct.order_id
            INNER JOIN
                df_Payments Payment ON _Order.order_id = Payment.order_id
            GROUP BY
                Customer.customer_id
            ORDER BY
                TotalPaymentValue DESC
            LIMIT {top}";
        
        var result = await context.Database
            .SqlQuery<PerCustomerDTO>(query)
            .ToListAsync();
        
        return result;
    }

    public async Task<List<PerStateDTO>> PerState()
    {
        FormattableString query = $@"
            SELECT
                Customer.customer_state AS State,
                COUNT(_Order.order_id) AS QuantityOrders,
                SUM(Payment.payment_value) AS TotalPaymentValue
            FROM
                df_Customers Customer
            INNER JOIN
                df_Orders _Order ON Customer.customer_id = _Order.customer_id
            INNER JOIN
                df_OrderItems OrderProduct ON _Order.order_id = OrderProduct.order_id
            INNER JOIN
                df_Payments Payment ON _Order.order_id = Payment.order_id
            GROUP BY
                Customer.customer_state
            ORDER BY Customer.customer_state ASC";
        
        var result = await context.Database
            .SqlQuery<PerStateDTO>(query)
            .ToListAsync();
        
        return result;
    }

    public async Task<List<PerCityDTO>> PerCity(int top)
    {
        FormattableString query = $@"
            SELECT
                Customer.customer_city AS City,
                Customer.customer_state AS State,
                COUNT(_Order.order_id) AS QuantityPurchase,
                SUM(Payment.payment_value) AS TotalPaymentValue
            FROM
                df_Customers Customer
            INNER JOIN
                df_Orders _Order ON Customer.customer_id = _Order.customer_id
            INNER JOIN
                df_OrderItems OrderProduct ON _Order.order_id = OrderProduct.order_id
            INNER JOIN
                df_Payments Payment ON _Order.order_id = Payment.order_id
            GROUP BY
                Customer.customer_city
            ORDER BY Payment.payment_value DESC
            LIMIT {top}";
        
        var result = await context.Database
            .SqlQuery<PerCityDTO>(query)
            .ToListAsync();
        
        return result;
    }
}
