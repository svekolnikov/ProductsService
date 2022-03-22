namespace ProductsService.Models.Interfaces;

public interface IEntity
{
    int Id { get; set; }
    string Name { get; set; }
    bool IsDeleted { get; set; }
}