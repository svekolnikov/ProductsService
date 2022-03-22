namespace ProductsService.DTO
{
    public class ServiceResultDto<T> where T : class
    {
        public T? Data { get; set; }
    }
}
