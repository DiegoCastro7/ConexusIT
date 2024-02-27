using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmisorConfiguration : IEntityTypeConfiguration<Emisor>
    {
        public void Configure(EntityTypeBuilder<Emisor> builder)
        {
            builder.HasKey(e => e.Identificacion).HasName("PRIMARY");

            builder.ToTable("emisor");

            builder.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .HasColumnName("identificacion");
            builder.Property(e => e.ComplementosDireccion)
                .HasMaxLength(50)
                .HasColumnName("complementos_direccion");
            builder.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .HasColumnName("razon_social");
            builder.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        }
    }
}
