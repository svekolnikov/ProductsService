using ProductsService.Models.Interfaces;

namespace ProductsService.DAL.Repositories.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default);

    Task<T?> GetByIdAsync(int id, CancellationToken cancel = default);

    Task<int> AddAsync(T item, CancellationToken cancel = default);

    Task<bool> UpdateAsync(T item, CancellationToken cancel = default);

    Task<bool> SoftDeleteAsync(int id, CancellationToken cancel = default);

    Task<T?> GetByNameAsync(string name, CancellationToken cancel = default);
}