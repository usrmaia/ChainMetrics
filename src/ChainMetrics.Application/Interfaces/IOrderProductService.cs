using AutoFilterer.Types;

using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Application.Interfaces;

public interface IOrderProductService
{
    Task<List<OrderProduct>> Query(PaginationFilterBase filter);
}
