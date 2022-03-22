namespace ProductsService.Services.Interfaces;

public interface IBrandsClient<T> where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancel = default);
}