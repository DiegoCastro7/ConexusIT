using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Emisor> Emisors { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=conexusit", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .HasColumnName("identificacion");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.ComplementosDireccion)
                .HasMaxLength(50)
                .HasColumnName("complementos_direccion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalle_factura");

            entity.HasIndex(e => e.IdFactura, "id_factura");

            entity.HasIndex(e => e.IdProducto, "id_producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.IdProducto)
                .HasMaxLength(10)
                .HasColumnName("id_producto");
            entity.Property(e => e.PrecioUnidad)
                .HasPrecision(15, 2)
                .HasColumnName("precio_unidad");
            entity.Property(e => e.Subtotal)
                .HasPrecision(15, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_factura_ibfk_2");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_factura_ibfk_1");
        });

        modelBuilder.Entity<Emisor>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PRIMARY");

            entity.ToTable("emisor");

            entity.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .HasColumnName("identificacion");
            entity.Property(e => e.ComplementosDireccion)
                .HasMaxLength(50)
                .HasColumnName("complementos_direccion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .HasColumnName("razon_social");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PRIMARY");

            entity.ToTable("factura");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdEmisor, "id_emisor");

            entity.Property(e => e.IdFactura)
                .ValueGeneratedNever()
                .HasColumnName("id_factura");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(10)
                .HasColumnName("id_cliente");
            entity.Property(e => e.IdEmisor)
                .HasMaxLength(10)
                .HasColumnName("id_emisor");
            entity.Property(e => e.TotalFactura)
                .HasPrecision(15, 2)
                .HasColumnName("total_factura");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factura_ibfk_1");

            entity.HasOne(d => d.IdEmisorNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEmisor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factura_ibfk_2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .HasColumnName("codigo");
            entity.Property(e => e.DescripcionTexto)
                .HasColumnType("text")
                .HasColumnName("descripcion_texto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
