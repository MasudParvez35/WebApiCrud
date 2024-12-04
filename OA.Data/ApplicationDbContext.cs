using Microsoft.EntityFrameworkCore;
using OA.Core.Domain;

namespace OA.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
}
