using System.ComponentModel.DataAnnotations;
using ProductsService.Models.Base;

namespace ProductsService.Models;

public class Product : Entity
{
    [Required]
    public string SizeRf { get; set; } = null!;

    [Required]
    public int BrandId { get; set; }
}