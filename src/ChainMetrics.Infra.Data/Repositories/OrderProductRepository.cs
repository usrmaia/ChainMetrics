using AutoFilterer.Extensions;
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;

using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;
using ChainMetrics.Infra.Data.Context;

namespace ChainMetrics.Infra.Data.Repositories;

public class OrderProductRepository(AppDbContext context) : BaseRepository<OrderProduct>(context), IOrderProductRepository
{
    public Task<List<OrderProduct>> Query(PaginationFilterBase filter)
    {
        return context.OrderProducts
            .ApplyFilter(filter)
            .ToListAsync();
    }
}
