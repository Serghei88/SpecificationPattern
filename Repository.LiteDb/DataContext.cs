using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.LiteDb.Entities;

namespace Repository.LiteDb;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
    public DbSet<User> Users { get; set; }
}