namespace BrandsService.DTO;

public class BrandDto
{
    public long Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Список допустимых размеров одежды
    /// </summary>
    public IEnumerable<AllowedSizeDto> AllowedSizes { get; set; } = null!;
}