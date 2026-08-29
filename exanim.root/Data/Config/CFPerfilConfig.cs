using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Config;

public class CFPerfilConfig : IEntityTypeConfiguration<CFPerfil>
{
    public void Configure(EntityTypeBuilder<CFPerfil> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_CFPerfil");
        builder.ToTable("CFPerfil");

        builder.Property(e => e.Nombre).HasMaxLength(15)
            .IsUnicode(false);

        builder.HasMany(e => e.Roles)
            .WithOne()
            .HasForeignKey(e => e.PerfilId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}