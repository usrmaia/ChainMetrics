using AutoFilterer.Types;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Application.Interfaces;

public interface IPaymentService
{
    Task<List<Payment>> Query(PaginationFilterBase filter);
    Task<List<PerTypeDTO>> PerType();
}
