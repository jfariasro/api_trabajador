using System;
using System.Collections.Generic;
using ApiTrabajador.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTrabajador.DAL.Context;

public partial class DbapitrabajadorContext : DbContext
{
    public DbapitrabajadorContext()
    {
    }

    public DbapitrabajadorContext(DbContextOptions<DbapitrabajadorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Pagotrabajador> Pagotrabajadors { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Idcargo).HasName("PK__cargo__0515A5ADA757BFB7");

            entity.ToTable("cargo");

            entity.Property(e => e.Idcargo).HasColumnName("idcargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Pagotrabajador>(entity =>
        {
            entity.HasKey(e => e.Idpagotrabajador).HasName("PK__pagotrab__5601FA3E254929AE");

            entity.ToTable("pagotrabajador");

            entity.Property(e => e.Idpagotrabajador).HasColumnName("idpagotrabajador");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fechapago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechapago");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");
            entity.Property(e => e.Totalpago)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalpago");

            entity.HasOne(d => d.TrabajadorNavigation).WithMany(p => p.Pagotrabajadors)
                .HasForeignKey(d => d.Idtrabajador)
                .HasConstraintName("FK__pagotraba__idtra__2D27B809");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.Idtrabajador).HasName("PK__trabajad__765CB464BE5DCC60");

            entity.ToTable("trabajador");

            entity.Property(e => e.Idtrabajador).HasColumnName("idtrabajador");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcargo).HasColumnName("idcargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Trabajadors)
                .HasForeignKey(d => d.Idcargo)
                .HasConstraintName("FK__trabajado__idcar__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
