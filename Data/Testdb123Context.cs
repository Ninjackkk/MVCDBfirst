using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVCDBFirst.Models;

namespace MVCDBFirst.Data;

public partial class Testdb123Context : DbContext
{
    public Testdb123Context()
    {
    }

    public Testdb123Context(DbContextOptions<Testdb123Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Crud> Cruds { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Product1> Products1 { get; set; }

    public virtual DbSet<ProductsTable> ProductsTables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("Cart");

            entity.Property(e => e.Suser).HasColumnName("suser");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.ToTable("emps");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83FE4C484E0");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pcat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pcat");
            entity.Property(e => e.Pname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pname");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Product1>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("products");
        });

        modelBuilder.Entity<ProductsTable>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("ProductsTable");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
