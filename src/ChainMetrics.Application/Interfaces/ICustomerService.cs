using AutoFilterer.Types;

using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;

namespace ChainMetrics.Application.Interfaces;

public interface ICustomerService
{
    Task<List<Customer>> Query(PaginationFilterBase filter);
    Task<List<PerCustomerDTO>> TopExpensiveCustomers(int top);
    Task<List<PerStateDTO>> PerState();
    Task<List<PerCityDTO>> PerCity(int top);
}
