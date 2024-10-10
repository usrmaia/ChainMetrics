using AutoFilterer.Types;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<List<Payment>> Query(PaginationFilterBase filter);
    Task<List<PerTypeDTO>> PerType();
    Task<List<PerInstallmentsDTO>> PerInstallments();
}
