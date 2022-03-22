using BrandsService.DTO;
using ProductsService.DAL.Repositories.Interfaces;
using ProductsService.DTO;
using ProductsService.Models;
using ProductsService.Services.Interfaces;

namespace ProductsService.Services.Clients;

public class BrandsClient : IBrandsClient<BrandDto>
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BrandsClient> _logger;

    public BrandsClient(HttpClient httpClient, ILogger<BrandsClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<BrandDto?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResultDto<BrandDto>>($"api/brands/{id}", cancel).ConfigureAwait(false);
        return result?.Data;
    }
}