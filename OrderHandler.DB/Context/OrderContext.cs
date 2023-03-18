using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.Data;
using OrderHandler.DB.Configurations;

namespace OrderHandler.DB.Context;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public OrderContext()
        => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=OrderData.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }

    public int GetLastIndex()
    {
        Order? lastOrder = Orders.OrderBy(order => order.Id).LastOrDefault();

        if (lastOrder is not null)
            return lastOrder.Id;

        return 0;
    }
}