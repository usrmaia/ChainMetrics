using AutoFilterer.Types;
using Microsoft.AspNetCore.Mvc;

using ChainMetrics.Domain.Repositories;

namespace ChainMetrics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Query([FromQuery] PaginationFilterBase filter) => Ok(await productRepository.Query(filter));

    [HttpGet("per-category")]
    public async Task<IActionResult> PerCategory() => Ok(await productRepository.PerCategory());
}
