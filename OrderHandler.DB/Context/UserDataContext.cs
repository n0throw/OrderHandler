using OrderHandler.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Context;

public class UserDataContext : DbContext
{
    public DbSet<UserData> Users => Set<UserData>();
    public UserDataContext()
        => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=UserData.db");

    private static readonly Func<UserDataContext, int, UserData?> userDataById =
        EF.CompileQuery((UserDataContext db, int id) =>
         db.Users.Include(c => c.Company).FirstOrDefault(c => c.Id == id));
}