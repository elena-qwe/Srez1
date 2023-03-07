using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Srez1.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InfoUser> InfoUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=q");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("type_pay", new[] { "cash", "credit" })
            .HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<InfoUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("InfoUser_pkey");

            entity.ToTable("InfoUser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressHome)
                .HasMaxLength(50)
                .HasColumnName("address_home");
            entity.Property(e => e.BirthdayDate).HasColumnName("birthday_date");
            entity.Property(e => e.PhoneNumber)
                .HasPrecision(11)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("first_name");
            entity.Property(e => e.IdInfoUser).HasColumnName("idInfoUser");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .HasColumnName("middle_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
