﻿
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

#nullable disable

using DependencyInjectionConsoleApplication.Data.Configurations;
using DependencyInjectionSimple.Models;

namespace DependencyInjectionConsoleApplication.Data;

public partial class PizzaContext : DbContext
{
    public PizzaContext()
    {
    }

    public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new OrdersConfiguration());
        modelBuilder.ApplyConfiguration(new ProductsConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}