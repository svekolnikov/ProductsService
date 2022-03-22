using Microsoft.EntityFrameworkCore;
using ProductsService.DAL.Context;
using ProductsService.DAL.Repositories.Interfaces;
using ProductsService.Models.Interfaces;

namespace ProductsService.DAL.Repositories;

public class DbRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<DbRepository<T>> _logger;

    protected DbSet<T> Set { get; }
    protected virtual IQueryable<T> Items => Set;

    public DbRepository(ApplicationDbContext dbContext, ILogger<DbRepository<T>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;

        Set = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default)
    {
        var result = await Items.ToArrayAsync(cancel).ConfigureAwait(false);
        return result;
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        var result = await Items.FirstOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);
        return result;
    }

    public async Task<int> AddAsync(T item, CancellationToken cancel = default)
    {
        item.IsDeleted = false;
        await Set.AddAsync(item, cancel).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(cancel);
        _logger.LogInformation("Entity {0} added to database", item);
        return item.Id;
    }

    public async Task<bool> UpdateAsync(T item, CancellationToken cancel = default)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);

        _logger.LogInformation("Entity {0} has updated", item);

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id, CancellationToken cancel = default)
    {
        var entity = await GetByIdAsync(id, cancel).ConfigureAwait(false);
        if (entity is null)
        {
            _logger.LogInformation("Entity {0} not found", id);
            return false;
        }
        entity.IsDeleted = true;
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancel);

        _logger.LogInformation("Entity {0} deleted from database", id);

        return true;
    }

    public async Task<T?> GetByNameAsync(string name, CancellationToken cancel = default)
    {
        return await Items.FirstOrDefaultAsync(item =>
                item.Name == name, cancel)
            .ConfigureAwait(false);
    }
}