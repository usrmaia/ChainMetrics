using AutoFilterer.Types;
using Microsoft.AspNetCore.Mvc;

using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderProductController(IOrderProductRepository orderProductRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Query([FromQuery] PaginationFilterBase filter) => Ok(await orderProductRepository.Query(filter));
}
