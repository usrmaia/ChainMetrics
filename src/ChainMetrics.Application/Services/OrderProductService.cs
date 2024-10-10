using AutoFilterer.Types;

using ChainMetrics.Application.Interfaces;
using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.Application.Services;

public class OrderProductService(IOrderProductRepository orderProductRepository) : IOrderProductService
{
    public async Task<List<OrderProduct>> Query(PaginationFilterBase filter) => await orderProductRepository.Query(filter);
}
