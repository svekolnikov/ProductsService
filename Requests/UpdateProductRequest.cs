namespace ProductsService.Requests;

public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SizeRf { get; set; } = null!;
}