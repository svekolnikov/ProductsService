using ProductsService.Services.Interfaces;

namespace ProductsService.Services;

public class ServiceResult : IServiceResult
{
    public bool IsSuccess { get; set; }
    public IReadOnlyCollection<IFailureInformation>? Failures { get; init; }
}

public class ServiceResult<T> : ServiceResult, IServiceResult<T>
{
    public T? Data { get; set; }
}