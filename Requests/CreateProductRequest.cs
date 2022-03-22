namespace ProductsService.Requests;

public class CreateProductRequest
{
    public string SizeRf { get; set; } = null!;
    public int BrandId { get; set; }
}