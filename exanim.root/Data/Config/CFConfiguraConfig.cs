using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Config;

public class CFConfiguraConfig : IEntityTypeConfiguration<CFConfigura>
{
    public void Configure(EntityTypeBuilder<CFConfigura> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_CFConfigura");
        builder.ToTable("CFConfigura");

        builder.Property(e => e.Cadena).HasMaxLength(300)
            .IsUnicode(false);
        builder.Property(e => e.Fecha)
            .HasColumnType(Dbtas.Tdatetime);
        
        builder.HasIndex(e => new { e.AgenciaId, e.ParametroId })
            .IsUnique();
    }
}
