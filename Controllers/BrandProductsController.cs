using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Requests;
using ProductsService.Services.Interfaces;

namespace ProductsService.Controllers;

[Route("api")]
[ApiController]
public class BrandProductsController : ControllerBase
{
    private readonly IProductsService _productsService;
    private readonly ILogger<BrandProductsController> _logger;

    public BrandProductsController(
        IProductsService productsService, 
        ILogger<BrandProductsController> logger)
    {
        _productsService = productsService;
        _logger = logger;
    }

    /// <summary>
    /// Получить все товары бренда
    /// </summary>
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpGet("brand/{brandId}/products")]
    public async Task<IActionResult> GetAll(int brandId)
    {
        try
        {
            var serviceResult = await _productsService.GetAllProductsByBrandId(brandId);
            if (serviceResult.IsSuccess)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Получить товар по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var serviceResult = await _productsService.GetByIdAsync(id);
            if (serviceResult.IsSuccess)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Создать товар
    /// </summary>
    /// <param name="createProductRequest"></param>
    /// <returns></returns>
    [HttpPost("products")]
    public async Task<IActionResult> CreateAsync(CreateProductRequest createProductRequest)
    {
        try
        {
            var serviceResult = await _productsService.CreateAsync(createProductRequest);
            if (serviceResult.IsSuccess)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
    }

    public async Task<IActionResult> UpdateAsync(UpdateProductRequest productRequest)
    {
        try
        {
            var serviceResult = await _productsService.UpdateAsync(productRequest);
            if (serviceResult.IsSuccess)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
    }

    private void LogError(Exception e, [CallerMemberName] string methodName = null!)
    {
        _logger.LogError(e, "Error at {0}", methodName);
    }
}