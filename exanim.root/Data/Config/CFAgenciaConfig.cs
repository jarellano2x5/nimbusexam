using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Config;

public class CFAgenciaConfig : IEntityTypeConfiguration<CFAgencia>
{
    public void Configure(EntityTypeBuilder<CFAgencia> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_CFAgencia");
        builder.ToTable("CFAgencia");

        builder.Property(e => e.RFC).HasMaxLength(13)
            .IsUnicode(false).IsRequired();
        builder.Property(e => e.RazonSocial).HasMaxLength(150)
            .IsUnicode(false).IsRequired();
        builder.Property(e => e.Nombre).HasMaxLength(50)
            .IsUnicode(false).IsRequired();

        builder.HasMany<CFConfigura>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<CFOperador>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<CFTaller>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPClase>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPEstado>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPPieza>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<VECotizacion>()
            .WithOne()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}