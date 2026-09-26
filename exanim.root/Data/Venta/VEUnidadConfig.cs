using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Venta;

public class VEUnidadConfig : IEntityTypeConfiguration<VEUnidad>
{
    public void Configure(EntityTypeBuilder<VEUnidad> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_VEUnidad");
        builder.ToTable("VEUnidad");

        builder.Property(e => e.Placa).HasMaxLength(15)
            .IsUnicode(false);
        builder.Property(e => e.Modelo).HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.Anio).HasMaxLength(4)
            .IsUnicode(false);
        builder.Property(e => e.Color).HasMaxLength(15)
            .IsUnicode(false);
        builder.Property(e => e.Registrado).HasColumnType("datetime");

        builder.HasMany<OPOrden>()
            .WithOne(e => e.Unidad)
            .HasForeignKey(e => e.UnidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<VECotizacion>()
            .WithOne(e => e.Unidad)
            .HasForeignKey(e => e.UnidadId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}