using AutoFilterer.Types;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Application.Interfaces;

public interface IProductService
{
    Task<List<Product>> Query(PaginationFilterBase filter);
    Task<List<PerCategoryDTO>> PerCategory();
}
