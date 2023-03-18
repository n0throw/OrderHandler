using OrderHandler.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Context;

public class UserDataContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public UserDataContext()
        => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=UserData.db");
}