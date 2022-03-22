using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    { }

    /// <summary>
    /// Продукты
    /// </summary>
    public DbSet<Product> Products { get; set; } = null!;
}