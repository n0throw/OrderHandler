﻿using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.Data;
using OrderHandler.DB.Configurations;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.DB.Data.UserAdd;

namespace OrderHandler.DB;

public class Context : DbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderMain> OrderMains => Set<OrderMain>();
    public DbSet<DocConst> DocConsts => Set<DocConst>();
    public DbSet<DocTech> DocTechs => Set<DocTech>();
    public DbSet<Supply> Supplys => Set<Supply>();
    public DbSet<SawCenter> SawCenters => Set<SawCenter>();
    public DbSet<Edge> Edges => Set<Edge>();
    public DbSet<Additive> Additives => Set<Additive>();
    public DbSet<Milling> Millings => Set<Milling>();
    public DbSet<Grinding> Grindings => Set<Grinding>();
    public DbSet<Press> Presss => Set<Press>();
    public DbSet<Assembling> Assemblings => Set<Assembling>();
    public DbSet<Packing> Packings => Set<Packing>();
    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<Mounting> Mountings => Set<Mounting>();


    public DbSet<User> Users => Set<User>();
    public DbSet<CaseName> CaseNameS => Set<CaseName>();
    public DbSet<GivenName> GivenNameS => Set<GivenName>();

    public Context()
        => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=OrderHandlerData.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CaseNameConfiguration());
    }

    public int GetLastIndex()
    {
        Order? lastOrder = Orders.OrderBy(order => order.Id).LastOrDefault();

        if (lastOrder is not null)
            return lastOrder.Id;

        return 0;
    }
}