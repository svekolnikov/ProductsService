using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Requests;
using ProductsService.Services.Interfaces;

namespace ProductsService.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(
        IProductsService productsService, 
        ILogger<ProductsController> logger)
    {
        _productsService = productsService;
        _logger = logger;
    }

    /// <summary>
    /// Получить все товары
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var serviceResult = await _productsService.GetAllProductsAsync();
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
    [HttpGet("{id}")]
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
    [HttpPost("")]
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

    /// <summary>
    /// Обновить товар
    /// </summary>
    /// <param name="productRequest"></param>
    /// <returns></returns>
    [HttpPut("")]
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

    /// <summary>
    /// Soft Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteBrandAsync(int id)
    {
        try
        {
            var serviceResult = await _productsService.SoftDeleteBrandAsync(id);
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