using ProductsService.DTO;
using ProductsService.Requests;

namespace ProductsService.Services.Interfaces
{
    public interface IProductsService
    {
        Task<IServiceResult<IEnumerable<ProductDto>>> GetAllProductsAsync();
        Task<IServiceResult<ProductDto>> GetByIdAsync(int id);
        Task<IServiceResult> CreateAsync(CreateProductRequest createProductRequest);
        Task<IServiceResult> UpdateAsync(UpdateProductRequest productRequest);
        Task<IServiceResult> SoftDeleteBrandAsync(int id);
    }
}
