using AutoFilterer.Types;

using ChainMetrics.Application.Interfaces;
using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.Application.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public Task<List<Customer>> Query(PaginationFilterBase filter) => customerRepository.Query(filter);

    public Task<List<PerCustomerDTO>> TopExpensiveCustomers(int top) => customerRepository.TopExpensiveCustomers(top);

    public Task<List<PerStateDTO>> PerState() => customerRepository.PerState();

    public Task<List<PerCityDTO>> PerCity(int top) => customerRepository.PerCity(top);
}
