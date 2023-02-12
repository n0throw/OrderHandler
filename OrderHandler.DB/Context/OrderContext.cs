using OrderHandler.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Context;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public OrderContext()
        => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=OrderData.db");
}