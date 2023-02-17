using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;

namespace MotoApp.Data;

internal class MotoContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        base.OnConfiguring(option);
        option.UseInMemoryDatabase("MotoAppDb");
    }
}
