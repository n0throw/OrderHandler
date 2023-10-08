using Microsoft.EntityFrameworkCore;

using OrderHandler.DB.Data;
using OrderHandler.DB.Data.UserAdd;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.DB.Configurations;
using OrderHandler.DB.Configurations.OrderConf;
using OrderHandler.DB.Configurations.RoleConf;
using OrderHandler.DB.Configurations.UserConf;
using OrderHandler.DB.Data.RoleAdd;

namespace OrderHandler.DB;

public sealed class Context : DbContext {
    public DbSet<OrderInfo> OrderInfos => Set<OrderInfo>();
    public DbSet<Additive> Additives => Set<Additive>();
    public DbSet<Assembling> Assemblings => Set<Assembling>();
    public DbSet<DocConst> DocConsts => Set<DocConst>();
    public DbSet<DocTech> DocTeches => Set<DocTech>();
    public DbSet<Edge> Edges => Set<Edge>();
    public DbSet<Equipment> Equipment => Set<Equipment>();
    public DbSet<Grinding> Grindings => Set<Grinding>();
    public DbSet<Milling> Millings => Set<Milling>();
    public DbSet<Mounting> Mountings => Set<Mounting>();
    public DbSet<OrderMain> OrderMains => Set<OrderMain>();
    public DbSet<Packing> Packings => Set<Packing>();
    public DbSet<Press> Presses => Set<Press>();
    public DbSet<SawCenter> SawCenters => Set<SawCenter>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<Supply> Supplies => Set<Supply>();
    
    public DbSet<RoleInfo> RoleInfos => Set<RoleInfo>();
    public DbSet<RoleAuthority> RoleAuthorities => Set<RoleAuthority>();
    public DbSet<RoleAuthorityAvailableStateList> RoleAuthorityAvailableStateList => Set<RoleAuthorityAvailableStateList>();
    public DbSet<RoleAuthorityList> RoleAuthorityList => Set<RoleAuthorityList>();
    public DbSet<RoleAuthorityStateList> RoleAuthorityStateList => Set<RoleAuthorityStateList>();
    
    public DbSet<CaseName> CaseNames => Set<CaseName>();
    public DbSet<UserInfo> UserInfos => Set<UserInfo>();

    public Context()
        => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder/*.UseLazyLoadingProxies()*/.UseSqlite("Data Source=OrderHandlerData.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderInfosConfiguration());
        modelBuilder.ApplyConfiguration(new AdditivesConfiguration());
        modelBuilder.ApplyConfiguration(new AssemblingsConfiguration());
        modelBuilder.ApplyConfiguration(new DocConstsConfiguration());
        modelBuilder.ApplyConfiguration(new DocTechesConfiguration());
        modelBuilder.ApplyConfiguration(new EdgesConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        modelBuilder.ApplyConfiguration(new GrindingsConfiguration());
        modelBuilder.ApplyConfiguration(new MillingsConfiguration());
        modelBuilder.ApplyConfiguration(new MountingsConfiguration());
        modelBuilder.ApplyConfiguration(new OrderMainsConfiguration());
        modelBuilder.ApplyConfiguration(new PackingsConfiguration());
        modelBuilder.ApplyConfiguration(new PressesConfiguration());
        modelBuilder.ApplyConfiguration(new SawCentersConfiguration());
        modelBuilder.ApplyConfiguration(new ShipmentsConfiguration());
        modelBuilder.ApplyConfiguration(new SuppliesConfiguration());
        
        modelBuilder.ApplyConfiguration(new RoleInfosConfiguration());
        modelBuilder.ApplyConfiguration(new RoleAuthoritiesConfiguration());
        modelBuilder.ApplyConfiguration(new RoleAuthorityAvailableStateListConfiguration());
        modelBuilder.ApplyConfiguration(new RoleAuthorityListConfiguration());
        modelBuilder.ApplyConfiguration(new RoleAuthorityStateListConfiguration());
        
        modelBuilder.ApplyConfiguration(new UserInfosConfiguration());
        modelBuilder.ApplyConfiguration(new CaseNamesConfiguration());
    }
}