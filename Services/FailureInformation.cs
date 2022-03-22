using ProductsService.Services.Interfaces;

namespace ProductsService.Services
{
    /// <summary>
    /// Информация об ошибке
    /// </summary>
    public class FailureInformation : IFailureInformation
    {
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string Description { get; init; } = null!;
    }
}
