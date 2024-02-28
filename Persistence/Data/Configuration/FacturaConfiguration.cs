using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("factura");

            builder.HasIndex(e => e.IdCliente, "id_cliente");

            builder.HasIndex(e => e.IdEmisor, "id_emisor");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_factura");
            builder.Property(e => e.IdCliente)
                .HasMaxLength(10)
                .HasColumnName("id_cliente");
            builder.Property(e => e.IdEmisor)
                .HasMaxLength(10)
                .HasColumnName("id_emisor");
            builder.Property(e => e.TotalFactura)
                .HasPrecision(15, 2)
                .HasColumnName("total_factura");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factura_ibfk_1");

            builder.HasOne(d => d.IdEmisorNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEmisor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factura_ibfk_2");
        }
    }
}
