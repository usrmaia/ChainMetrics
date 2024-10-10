using AutoFilterer.Types;

using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Domain.Repositories;

public interface IOrderProductRepository
{
    Task<List<OrderProduct>> Query(PaginationFilterBase filter);
}
