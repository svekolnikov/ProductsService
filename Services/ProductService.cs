using AutoMapper;
using ProductsService.DAL.Repositories.Interfaces;
using ProductsService.DTO;
using ProductsService.Models;
using ProductsService.Requests;
using ProductsService.Services.Clients;
using ProductsService.Services.Interfaces;

namespace ProductsService.Services
{
    public class ProductService : IProductsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;
        private readonly BrandsClient _brandsClient;

        public ProductService(IMapper mapper, IRepository<Product> repository, BrandsClient brandsClient)
        {
            _mapper = mapper;
            _repository = repository;
            _brandsClient = brandsClient;
        }

        public async Task<IServiceResult<IEnumerable<ProductDto>>> GetAllProductsByBrandId(int brandId)
        {
            var productEntities = await _repository.GetAllAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(productEntities);

            return new ServiceResult<IEnumerable<ProductDto>>
                {IsSuccess = true, Data = productDtos, Failures = new List<IFailureInformation>()};
        }

        public async Task<IServiceResult<ProductDto>> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return new ServiceResult<ProductDto>
                { IsSuccess = true, Data = productDto, Failures = new List<IFailureInformation>() };
        }

        public async Task<IServiceResult> CreateAsync(CreateProductRequest createProductRequest)
        {
            var brandDto = await _brandsClient.GetByIdAsync(createProductRequest.BrandId);

            var isSizeExist = brandDto.AllowedSizes
                .Any(x => x.Rf == createProductRequest.SizeRf);

            if (!isSizeExist)
            {
                return new ServiceResult
                    { IsSuccess = true, Failures = new List<IFailureInformation>
                    {
                        new FailureInformation{ Description = $"У данного бренда отсутствует размер [{createProductRequest.SizeRf}]"}
                    } };
            }

            var productEntity = _mapper.Map<Product>(createProductRequest);

            await _repository.AddAsync(productEntity);

            return new ServiceResult
                { IsSuccess = true, Failures = new List<IFailureInformation>() };
        }
    }
}
