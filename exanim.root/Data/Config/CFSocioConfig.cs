using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Config;

public class CFSocioConfig : IEntityTypeConfiguration<CFSocio>
{
    public void Configure(EntityTypeBuilder<CFSocio> builder)
    {
        builder.HasKey(c => c.Id)
            .HasName("PK_CFSocio");
        builder.ToTable("CFSocio");
        
        builder.HasIndex(e => new { e.AgenciaId, e.UsuarioId })
            .IsUnique();
    }
}