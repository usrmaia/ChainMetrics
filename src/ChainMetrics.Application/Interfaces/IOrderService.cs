using AutoFilterer.Types;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Application.Interfaces;

public interface IOrderService
{
    Task<List<Order>> Query(PaginationFilterBase filter);
    Task<List<PerStatusDTO>> PerStatus();

}
