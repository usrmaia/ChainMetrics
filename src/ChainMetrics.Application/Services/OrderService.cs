using AutoFilterer.Types;

using ChainMetrics.Application.Interfaces;
using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<List<Order>> Query(PaginationFilterBase filter) => await orderRepository.Query(filter);

    public async Task<List<PerStatusDTO>> PerStatus() => await orderRepository.PerStatus();
}
