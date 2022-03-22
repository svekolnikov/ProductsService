using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductsService.Models.Interfaces;

namespace ProductsService.Models.Base;

public class Entity : IEntity
{
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column(TypeName = "nvarchar(200)")]
    [Required]
    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public override string ToString()
    {
        return Name;
    }
}