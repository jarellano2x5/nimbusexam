using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Venta;

public class VECotizacionConfig : IEntityTypeConfiguration<VECotizacion>
{
    public void Configure(EntityTypeBuilder<VECotizacion> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_VECotizacion");
        builder.ToTable("VECotizacion");

        builder.Property(e => e.Fecha)
            .HasColumnType(Dbtas.Tdatetime);
        builder.Property(e => e.Clave)
            .HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Vehiculo)
            .HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Monto)
            .HasColumnType(Dbtas.Tmoney);
        builder.Property(e => e.Vigencia)
            .HasColumnType(Dbtas.Tdate);

        builder.HasMany(e => e.Lineas)
            .WithOne()
            .HasForeignKey(e => e.CotizacionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}