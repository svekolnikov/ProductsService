namespace ProductsService.Requests;

public class CreateProductRequest
{
    public string Name { get; set; } = null!;
    public string SizeRf { get; set; } = null!;
    public int BrandId { get; set; }
}