﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpyStore.Models.Entities;

namespace SpyStore.DAL.EF
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
        }
        public StoreContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {
                //Should do something intelligent here
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;

                //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=SpyStore;Trusted_Connection=True;MultipleActiveResultSets=true;");
                optionsBuilder.UseSqlServer(@"Server=jenkins.spystore.local;Database=SpyStore;User Id=sa;Password=Password!");

                //@"Server=(localdb)\mssqllocaldb;Database=SpyStore;Trusted_Connection=True;MultipleActive
                //                                ResultSets=true;", options => options.EnableRetryOnFailure());
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartRecord> ShoppingCartRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress).HasName("IX_Customers").IsUnique();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
                entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
                entity.Property(e => e.OrderTotal)
                .HasColumnType("money")
                .HasComputedColumnSql("Store.GetOrderTotal([Id])");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.LineItemTotal).HasColumnType("money")
                .HasComputedColumnSql("[Quantity]*[UnitCost]");
                entity.Property(e => e.UnitCost).HasColumnType("money");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.UnitCost).HasColumnType("money");
                entity.Property(e => e.CurrentPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ShoppingCartRecord>(entity =>
            {
                entity.HasIndex(e => new { ShoppingCartRecordId = e.Id, e.ProductId, e.CustomerId })
                .HasName("IX_ShoppingCart")
                .IsUnique();
                entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
                entity.Property(e => e.Quantity).HasDefaultValue(1);
            });

        }

    }
}
