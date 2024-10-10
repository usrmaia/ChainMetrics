using AutoFilterer.Types;

using ChainMetrics.Application.Interfaces;
using ChainMetrics.Domain.DTOs;
using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.Application.Services;

public class PaymentService(IPaymentRepository paymentRepository) : IPaymentService
{
    public async Task<List<Payment>> Query(PaginationFilterBase filter) => await paymentRepository.Query(filter);

    public async Task<List<PerTypeDTO>> PerType() => await paymentRepository.PerType();
}
