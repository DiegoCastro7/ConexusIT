using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Identificacion).HasName("PRIMARY");

            builder.ToTable("cliente");

            builder.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .HasColumnName("identificacion");
            builder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            builder.Property(e => e.ComplementosDireccion)
                .HasMaxLength(50)
                .HasColumnName("complementos_direccion");
            builder.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");
            builder.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        }
    }
}
