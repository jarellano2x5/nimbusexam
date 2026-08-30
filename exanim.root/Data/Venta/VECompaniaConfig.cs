using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Venta;

public class VECompaniaConfig : IEntityTypeConfiguration<VECompania>
{
    public void Configure(EntityTypeBuilder<VECompania> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_VECompania");
        builder.ToTable("VECompania");

        builder.Property(e => e.RFC).HasMaxLength(13)
            .IsUnicode(false);
        builder.Property(e => e.RazonSocial).HasMaxLength(150)
            .IsUnicode(false);
        builder.Property(e => e.Nombre).HasMaxLength(50)
            .IsUnicode(false);

        builder.HasMany<VECliente>()
            .WithOne()
            .HasForeignKey(e => e.CompaniaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
        builder.HasMany<VECliente>()
            .WithOne(e => e.Compania)
            .HasForeignKey(e => e.CompaniaId)
            .IsRequired(false);
    }
}