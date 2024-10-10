using AutoFilterer.Types;
using Microsoft.AspNetCore.Mvc;

using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderRepository orderRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Query([FromQuery] PaginationFilterBase filter) => Ok(await orderRepository.Query(filter));

    [HttpGet("per-status")]
    public async Task<IActionResult> PerStatus() => Ok(await orderRepository.PerStatus());

    [HttpGet("per-purchase")]
    public async Task<IActionResult> PerPurchase() => Ok(await orderRepository.PerPurchase());
}
