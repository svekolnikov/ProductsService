using ProductsService.Models.Base;

namespace ProductsService.Models;

public class Brand : Entity
{
    /// <summary>
    /// Список допустимых размеров одежды
    /// </summary>
    public IEnumerable<AllowedSize> AllowedSizes { get; set; } = null!;
}