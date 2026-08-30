using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Config;

public class CFUsuarioConfig : IEntityTypeConfiguration<CFUsuario>
{
    public void Configure(EntityTypeBuilder<CFUsuario> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_CFUsuario");
        builder.ToTable("CFUsuario");

        builder.Property(e => e.Nombre).HasMaxLength(150)
            .IsUnicode(false);
        builder.Property(e => e.Usuario).HasMaxLength(20)
            .IsUnicode(false);
        builder.Property(e => e.Password).HasMaxLength(400)
            .IsUnicode(false);
        builder.Property(e => e.Correo).HasMaxLength(150)
            .IsUnicode(false);

        builder.HasMany(e => e.Socios)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .IsRequired();
        builder.HasMany<CFAgencia>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<CFOperador>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<CFTaller>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPAvance>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPOrden>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<OPPieza>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<VECotizacion>()
            .WithOne()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasMany<VECliente>()
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}