using AutoFilterer.Types;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> Query(PaginationFilterBase filter);
    Task<List<PerStatusDTO>> PerStatus();
    Task<List<PerPurchase>> PerPurchase();
}
