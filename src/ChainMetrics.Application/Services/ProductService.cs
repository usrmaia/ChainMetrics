using AutoFilterer.Types;

using ChainMetrics.Application.Interfaces;
using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<List<Product>> Query(PaginationFilterBase filter) => await productRepository.Query(filter);

    public async Task<List<PerCategoryDTO>> PerCategory() => await productRepository.PerCategory();
}
