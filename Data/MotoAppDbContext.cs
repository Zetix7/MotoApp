using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;

namespace MotoApp.Data;

public class MotoAppDbContext : DbContext
{
    public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.LogTo(Console.WriteLine);
}
