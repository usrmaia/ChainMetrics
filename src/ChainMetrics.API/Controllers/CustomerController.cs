using AutoFilterer.Types;
using Microsoft.AspNetCore.Mvc;

using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Query([FromQuery] PaginationFilterBase filter) => Ok(await customerRepository.Query(filter));

    [HttpGet("top-expensive")]
    public async Task<IActionResult> TopExpensiveCustomers([FromQuery] int top = 20) => Ok(await customerRepository.TopExpensiveCustomers(top));

    [HttpGet("per-state")]
    public async Task<IActionResult> PerState() => Ok(await customerRepository.PerState());

    [HttpGet("per-city")]
    public async Task<IActionResult> PerCity([FromQuery] int top = 20) => Ok(await customerRepository.PerCity(top));
}
