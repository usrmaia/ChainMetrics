using AutoFilterer.Types;
using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> Query(PaginationFilterBase filter);
    Task<List<PerCategoryDTO>> PerCategory();
}
