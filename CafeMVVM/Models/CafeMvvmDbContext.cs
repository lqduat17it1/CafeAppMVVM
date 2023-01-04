using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CafeMVVM.Models;

public partial class CafeMvvmDbContext : DbContext
{
    public CafeMvvmDbContext()
    {
    }

    public CafeMvvmDbContext(DbContextOptions<CafeMvvmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountModel> TblAccounts { get; set; }

    public virtual DbSet<MenuModel> TblMenus { get; set; }

    public virtual DbSet<ReceiptModel> TblReceipts { get; set; }

    public virtual DbSet<TableAreaModel> TblTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;User ID=sa;Password=lqduat99;Database=Cafe_MVVM_DB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountModel>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK_Username");

            entity.ToTable("tblAccount");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblMenu");

            entity.HasIndex(e => new { e.MenuId, e.MenuName, e.Price, e.Discount, e.Mcid }, "idx_Menu");

            entity.Property(e => e.Discount).HasDefaultValueSql("((0))");
            entity.Property(e => e.Mcid).HasColumnName("MCID");
            entity.Property(e => e.MenuId)
                .ValueGeneratedOnAdd()
                .HasColumnName("MenuID");
            entity.Property(e => e.MenuName).HasMaxLength(100);
        });

        modelBuilder.Entity<ReceiptModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblReceipt");

            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrintReceipt).HasDefaultValueSql("((0))");
            entity.Property(e => e.ReceiptId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ReceiptID");
            entity.Property(e => e.ReceiptStatus).HasDefaultValueSql("((0))");
            entity.Property(e => e.TableId).HasColumnName("TableID");
        });

        modelBuilder.Entity<TableAreaModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblTable");

            entity.HasIndex(e => new { e.TableId, e.TableName, e.TableStatus, e.AreaId }, "idx_table");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.TableId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TableID");
            entity.Property(e => e.TableName).HasMaxLength(100);
            entity.Property(e => e.TableStatus).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
