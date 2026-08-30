using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Opera;

public class OPEstadoConfig : IEntityTypeConfiguration<OPEstado>
{
    public void Configure(EntityTypeBuilder<OPEstado> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_OPEstado");
        builder.ToTable("OPEstado");

        builder.Property(e => e.Nombre).HasMaxLength(30)
            .IsUnicode(false).IsRequired();
        builder.Property(e => e.Code).HasMaxLength(15)
            .IsUnicode(false).IsRequired();

        builder.HasMany<OPAvance>()
            .WithOne()
            .HasForeignKey(e => e.EstadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPOrden>()
            .WithOne(e => e.Estado)
            .HasForeignKey(e => e.EstadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPPaso>()
            .WithOne()
            .HasForeignKey(e => e.PrevioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPPaso>()
            .WithOne()
            .HasForeignKey(e => e.AvanzaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
