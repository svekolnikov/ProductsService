namespace ProductsService.Services.Interfaces;

/// <summary>
/// Информация об ошибке
/// </summary>
public interface IFailureInformation
{
    /// <summary>
    /// Описание ошибки
    /// </summary>
    string Description { get; }
}