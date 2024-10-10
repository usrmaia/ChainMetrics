using AutoFilterer.Types;
using Microsoft.AspNetCore.Mvc;

using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController(IPaymentRepository paymentRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Query([FromQuery] PaginationFilterBase filter) => Ok(await paymentRepository.Query(filter));

    [HttpGet("per-type")]
    public async Task<IActionResult> PerType() => Ok(await paymentRepository.PerType());

    [HttpGet("per-installments")]
    public async Task<IActionResult> PerInstallments() => Ok(await paymentRepository.PerInstallments());
}
