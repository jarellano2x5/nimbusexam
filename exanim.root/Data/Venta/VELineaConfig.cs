using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Venta;

public class VELineaConfig : IEntityTypeConfiguration<VELinea>
{
    public void Configure(EntityTypeBuilder<VELinea> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_VELinea");
        builder.ToTable("VELinea");

        builder.Property(e => e.Clave).HasMaxLength(20)
            .IsUnicode(false).IsRequired();
        builder.Property(e => e.Unidad).HasMaxLength(15)
            .IsUnicode(false).IsRequired();
        builder.Property(e => e.Concepto).HasMaxLength(500)
            .IsUnicode(false).IsRequired();
        builder.Property(e => e.Cantidad)
            .HasColumnType(Dbtas.Tmoney);
        builder.Property(e => e.Precio)
            .HasColumnType(Dbtas.Tmoney);
        builder.Ignore(e => e.Importe);
    }
}