using ProductsService.Models.Base;

namespace ProductsService.Models;

public class AllowedSize : Entity
{
    public string Rf { get; set; } = null!;
    public string Own { get; set; } = null!;
}