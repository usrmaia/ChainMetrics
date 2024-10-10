using AutoFilterer.Extensions;
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;
using ChainMetrics.Infra.Data.Context;

namespace ChainMetrics.Infra.Data.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public Task<List<Order>> Query(PaginationFilterBase filter)
    {
        return context.Orders
            .ApplyFilter(filter)
            .ToListAsync();
    }

    public Task<List<PerStatusDTO>> PerStatus()
    {
        var result = context.Orders
        .GroupBy(x => x.Status)
        .Select(x => new
        {
            Status = x.Key,
            Quantity = x.Count(),
            Orders = x.ToList()
        })
        .AsEnumerable()
        .Select(x => new PerStatusDTO
        {
            Status = x.Status,
            Quantity = x.Quantity,
            TotalDeliveryHours = x.Orders.Average(o =>
                o.DeliveredTimestamp.HasValue 
                ? (o.DeliveredTimestamp - o.PurchaseTimestamp).Value.TotalHours
                : 0
            )
        })
        .ToList();
    
        return Task.FromResult(result);
    }

    public Task<List<PerPurchase>> PerPurchase()
    {
        var result = context.Orders
        .GroupBy(x => x.PurchaseTimestamp.Date)
        .Select(x => new
        {
            PurchaseDate = x.Key,
            Quantity = x.Count()
        })
        .AsEnumerable()
        .Select(x => new PerPurchase
        {
            PurchaseDate = DateOnly.FromDateTime(x.PurchaseDate),
            Quantity = x.Quantity
        })
        .ToList();

        return Task.FromResult(result);
    }
}
